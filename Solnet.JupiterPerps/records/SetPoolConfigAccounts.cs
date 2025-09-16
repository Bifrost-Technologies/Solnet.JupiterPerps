using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record SetPoolConfigAccounts
{
    public required PublicKey Admin { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
}
