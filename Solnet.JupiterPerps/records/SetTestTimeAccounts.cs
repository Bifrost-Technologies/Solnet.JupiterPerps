using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record SetTestTimeAccounts
{
    public required PublicKey Admin { get; set; }
    public required PublicKey Perpetuals { get; set; }
}
