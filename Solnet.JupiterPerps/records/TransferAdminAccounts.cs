using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record TransferAdminAccounts
{
    public required PublicKey Admin { get; set; }
    public required PublicKey NewAdmin { get; set; }
    public required PublicKey Perpetuals { get; set; }
}
