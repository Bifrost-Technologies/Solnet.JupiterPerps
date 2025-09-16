using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record LiquidateFullPosition4Accounts
{
    public required PublicKey Signer { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey Position { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey CustodyDovesPriceAccount { get; set; }
    public required PublicKey CustodyPythnetPriceAccount { get; set; }
    public required PublicKey CollateralCustody { get; set; }
    public required PublicKey CollateralCustodyDovesPriceAccount { get; set; }
    public required PublicKey CollateralCustodyPythnetPriceAccount { get; set; }
    public required PublicKey CollateralCustodyTokenAccount { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
