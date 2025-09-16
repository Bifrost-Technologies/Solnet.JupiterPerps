using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record OperatorSetCustodyConfigAccounts
{
    public required PublicKey Operator { get; set; }
    public required PublicKey Custody { get; set; }
}
