using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record IncreasePositionWithInternalSwapAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey PositionRequest { get; set; }
    public required PublicKey PositionRequestAta { get; set; }
    public required PublicKey Position { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey CustodyDovesPriceAccount { get; set; }
    public required PublicKey CustodyPythnetPriceAccount { get; set; }
    public required PublicKey CollateralCustody { get; set; }
    public required PublicKey CollateralCustodyDovesPriceAccount { get; set; }
    public required PublicKey CollateralCustodyPythnetPriceAccount { get; set; }
    public required PublicKey CollateralCustodyTokenAccount { get; set; }
    public required PublicKey ReceivingCustody { get; set; }
    public required PublicKey ReceivingCustodyDovesPriceAccount { get; set; }
    public required PublicKey ReceivingCustodyPythnetPriceAccount { get; set; }
    public required PublicKey ReceivingCustodyTokenAccount { get; set; }
    public required PublicKey TokenProgram { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
