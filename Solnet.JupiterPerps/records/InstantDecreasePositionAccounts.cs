using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record InstantDecreasePositionAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey ApiKeeper { get; set; }
    public required PublicKey Owner { get; set; }
    public required PublicKey ReceivingAccount { get; set; }
    public required PublicKey TransferAuthority { get; set; }
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
    public required PublicKey DesiredMint { get; set; }
    public required PublicKey Referral { get; set; }
    public required PublicKey TokenProgram { get; set; }
    public required PublicKey AssociatedTokenProgram { get; set; }
    public required PublicKey SystemProgram { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
