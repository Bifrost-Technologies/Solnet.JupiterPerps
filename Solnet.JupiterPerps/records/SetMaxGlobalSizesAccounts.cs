using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record SetMaxGlobalSizesAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey Pool { get; set; }
}
