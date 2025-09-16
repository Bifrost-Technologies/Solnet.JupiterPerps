<p align="center">
	<strong>Solnet.JupiterPerps</strong><br/>
	Professional C# SDK & Client for interacting with the <a href="https://jup.ag" target="_blank">Jupiter</a> Perpetuals on-chain program on <a href="https://solana.com" target="_blank">Solana</a>.
</p>

---

## Overview
`Solnet.JupiterPerps` is a .NET 8.0 library that enables developers, trading bots, quant systems, and backend services to read on-chain state and craft valid transactions for Jupiter's Perpetuals Program. It builds on top of the official Solnet stack (`Solana.Rpc`, `Solana.Programs`, `Solana.Extensions`, `Solana.KeyStore`).

The SDK exposes:
* Low-level instruction builders (via `PerpetualsProgram`) for every supported on-chain instruction.
* A typed async client (`PerpetualsClient`) to fetch and deserialize program accounts (pools, custodies, positions, position requests, etc.).
* PDA helpers in `PDALookup` to derive program-derived addresses deterministically.
* Strongly-typed parameters & account record classes under `Records/` and `Types/` namespaces.

## Key Capabilities (Current)
* Discover and load program state: Perpetuals config, pools, custodies, positions, position requests.
* Create increase & decrease position market requests including SOL collateral wrapping.
* Build raw Solana `TransactionInstruction` objects for advanced / custom pipelines.
* Liquidate or close positions (where permitted by program state and rules).
* Derive PDAs for custody, pool, and perpetuals accounts.

## Architecture at a Glance
```
Solnet.JupiterPerps/
 ├─ JupiterPerpsProgram.cs     // Static instruction builders (serialization + account metas)
 ├─ JupiterPerpsClient.cs      // High-level async RPC client wrappers
 ├─ Utils.cs                   // PDA derivation helpers (PDALookup)
 ├─ Errors.cs                  // Enum mapping on-chain error codes → names
 ├─ Records/                   // Account meta groupings for each instruction
 └─ Types/                     // Parameter + account layout types (Borsh-like serialization)
```

### Instruction Builders
Each static method on `PerpetualsProgram` returns a fully populated `TransactionInstruction`:
```csharp
var ix = PerpetualsProgram.IncreasePosition4(accounts, paramsObj);
```
These builders:
1. Set the correct discriminator / instruction tag (first 8 bytes).
2. Serialize parameters into the byte buffer.
3. Attach ordered account metas (read-only / writable / signer flags) as required by the on-chain program.

### High-Level Client
`PerpetualsClient` wraps RPC account fetch flows with discriminator-based filtering using `getProgramAccounts` and typed deserialization:
```csharp
var rpc = ClientFactory.GetClient(Cluster.MainNet); // from Solnet
var perpClient = new PerpetualsClient(rpc);
var pools = await perpClient.GetPoolsAsync();
```

### PDA Utilities
Deterministic derivations to avoid manual seed handling:
```csharp
PublicKey custody = PDALookup.FindCustodyPDA(tokenMint);
PublicKey pool    = PDALookup.FindPoolPDA(ownerOrSeedKey);
PublicKey perpCfg = PDALookup.FindPerpetualsPDA(adminOrSeedKey);
```

## Installation
Add the project as a dependency (until published to NuGet):
1. Clone the repository.
2. Reference the `.csproj` from your solution or add a project reference:
	 ```xml
	 <ItemGroup>
		 <ProjectReference Include="..\Solnet.JupiterPerps\Solnet.JupiterPerps.csproj" />
	 </ItemGroup>
	 ```
3. Restore & build:
	 ```powershell
	 dotnet restore; dotnet build -c Release
	 ```

Planned: Publish to NuGet as `Solnet.JupiterPerps` once APIs stabilize.

## Quick Start Example: Open / Increase a Position
```csharp
using Solnet.JupiterPerps;
using Solnet.Wallet;
using Solnet.Rpc;
using Solnet.Rpc.Types;

// 1. Initialize RPC + wallet
var rpc = ClientFactory.GetClient(Cluster.MainNet);
var trader = new Wallet.Wallet(new Mnemonic("<seed words>"));
var perpClient = new PerpetualsClient(rpc);

// 2. Build accounts + params (illustrative – adapt to real account keys)
var accounts = new CreateIncreasePositionMarketRequestAccounts
{
		// Populate: user account, pool, custody, position request PDA, token accounts, oracle feeds, etc.
};
var parameters = new CreateIncreasePositionMarketRequestParams
{
		// Populate: size, leverage, side, slippage tolerances, etc.
};

// 3. Fund with SOL collateral (lamports) and submit combined transaction
ulong collateralLamports = 1_000_000_000; // 1 SOL example
string rawResponse = await perpClient.SendCreateIncreasePositionAsync(trader.Account, collateralLamports, accounts, parameters);
Console.WriteLine(rawResponse);
```

## Building Custom Transactions
If you need to batch multiple Jupiter Perps instructions, you can manually chain builders:
```csharp
var ix1 = PerpetualsProgram.CreateIncreasePositionMarketRequest(accts1, params1);
var ix2 = PerpetualsProgram.InstantCreateLimitOrder(accts2, limitParams);

var blockhash = (await rpc.GetLatestBlockHashAsync()).Result.Value.Blockhash;
var tx = new TransactionBuilder()
		.SetRecentBlockHash(blockhash)
		.SetFeePayer(traderPubKey)
		.AddInstruction(ComputeBudgetProgram.SetComputeUnitLimit(120_000))
		.AddInstruction(ix1)
		.AddInstruction(ix2)
		.Build(traderAccount);

var sig = await rpc.SendTransactionAsync(tx);
```

## Error Handling
On-chain custom errors are enumerated in `PerpetualsErrorKind` (see `Errors.cs`). A non-exhaustive subset:
| Code | Name | Meaning |
|------|------|---------|
| 6000 | MathOverflow | Internal arithmetic overflow detected |
| 6022 | MaxLeverage | Requested leverage exceeds pool or custody limits |
| 6021 | MaxPriceSlippage | Slippage tolerance breached |
| 6019 | InsufficientTokenAmount | Not enough tokens provided for the action |
| 6063 | CannotLiquidate | Liquidation conditions not met |

When a transaction fails, decode the `InstructionError` → custom error code and map to the enum for user-friendly messaging.

## Security & Reliability Notes
* Always verify oracle freshness (stale price errors 6003 / 6046 appear if not).
* Wrap SOL correctly (the helper flow in `SendCreateIncreasePositionAsync` creates and syncs the associated wSOL ATA).
* Monitor compute unit usage; complex position flows may require budget increases (`ComputeBudgetProgram`).
* Validate PDAs locally rather than trusting external input.

## Roadmap / Planned Enhancements
* Automatic position close helper (removing current manual requirement).
* Take Profit / Stop Loss management & update flows (TPSL convenience wrappers).
* Signed backend co-signature integration (Jupiter API) for close path optimizations.
* NuGet packaging & semantic versioning.
* Expanded high-level convenience methods (e.g., margin health checks, liquidation candidates scan).
* Optional caching layer for frequently polled accounts.

## Contributing
Pull requests welcome. Please ensure:
1. Deterministic instruction ordering.
2. No breaking changes to public method signatures without discussion.
3. Clear commit messages referencing instruction / feature touched.

## Development
```powershell
git clone https://github.com/Bifrost-Technologies/Solnet.JupiterPerps.git
cd Solnet.JupiterPerps/Solnet.JupiterPerps
dotnet build
```

Run a quick smoke test by attempting to fetch pools:
```csharp
var rpc = ClientFactory.GetClient(Cluster.MainNet);
var client = new PerpetualsClient(rpc);
var pools = await client.GetPoolsAsync();
Console.WriteLine($"Pools fetched: {pools.ParsedResult?.Count}");
```

## Disclaimer
This SDK is an independent, community-maintained integration layer. Use at your own risk. Always test with small amounts and review on-chain program updates.

## License
MIT – see `LICENSE`.

---
Questions or feature requests? Open an issue or discussion on the repository.
