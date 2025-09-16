using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record ReallocCustodyAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey SystemProgram { get; set; }
    public required PublicKey Rent { get; set; }
}
