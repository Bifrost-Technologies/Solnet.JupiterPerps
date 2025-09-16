using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record WithdrawFees2Accounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey TransferAuthority { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey CustodyTokenAccount { get; set; }
    public required PublicKey CustodyDovesPriceAccount { get; set; }
    public required PublicKey CustodyPythnetPriceAccount { get; set; }
    public required PublicKey ReceivingTokenAccount { get; set; }
    public required PublicKey TokenProgram { get; set; }
}
