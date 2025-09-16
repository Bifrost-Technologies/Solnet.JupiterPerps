using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record SetCustodyConfigAccounts
{
    public required PublicKey Admin { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Custody { get; set; }
}
