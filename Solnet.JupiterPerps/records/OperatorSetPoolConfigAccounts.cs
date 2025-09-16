using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record OperatorSetPoolConfigAccounts
{
    public required PublicKey Operator { get; set; }
    public required PublicKey Pool { get; set; }
}
