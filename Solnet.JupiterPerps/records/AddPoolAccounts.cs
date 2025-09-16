using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record AddPoolAccounts
{
    public required PublicKey Admin { get; set; }
    public required PublicKey TransferAuthority { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey LpTokenMint { get; set; }
    public required PublicKey SystemProgram { get; set; }
    public required PublicKey TokenProgram { get; set; }
    public required PublicKey Rent { get; set; }
}
