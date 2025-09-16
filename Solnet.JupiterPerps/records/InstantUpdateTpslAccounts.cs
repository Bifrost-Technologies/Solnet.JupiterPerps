using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record InstantUpdateTpslAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey ApiKeeper { get; set; }
    public required PublicKey Owner { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey Position { get; set; }
    public required PublicKey PositionRequest { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey CustodyDovesPriceAccount { get; set; }
    public required PublicKey CustodyPythnetPriceAccount { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
