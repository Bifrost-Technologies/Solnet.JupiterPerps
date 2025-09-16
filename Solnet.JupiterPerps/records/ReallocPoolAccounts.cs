using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record ReallocPoolAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey SystemProgram { get; set; }
    public required PublicKey Rent { get; set; }
}
