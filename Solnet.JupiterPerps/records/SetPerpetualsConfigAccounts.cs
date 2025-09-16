using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record SetPerpetualsConfigAccounts
{
    public required PublicKey Admin { get; set; }
    public required PublicKey Perpetuals { get; set; }
}
