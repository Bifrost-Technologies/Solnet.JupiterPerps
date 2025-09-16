using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record Swap2Accounts
{
    public required PublicKey Owner { get; set; }
    public required PublicKey FundingAccount { get; set; }
    public required PublicKey ReceivingAccount { get; set; }
    public required PublicKey TransferAuthority { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey ReceivingCustody { get; set; }
    public required PublicKey ReceivingCustodyDovesPriceAccount { get; set; }
    public required PublicKey ReceivingCustodyPythnetPriceAccount { get; set; }
    public required PublicKey ReceivingCustodyTokenAccount { get; set; }
    public required PublicKey DispensingCustody { get; set; }
    public required PublicKey DispensingCustodyDovesPriceAccount { get; set; }
    public required PublicKey DispensingCustodyPythnetPriceAccount { get; set; }
    public required PublicKey DispensingCustodyTokenAccount { get; set; }
    public required PublicKey TokenProgram { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
