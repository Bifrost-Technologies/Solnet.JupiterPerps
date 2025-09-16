using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record GetAssetsUnderManagement2Accounts
{
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
}
