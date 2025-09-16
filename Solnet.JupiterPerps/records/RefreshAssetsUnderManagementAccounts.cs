using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record RefreshAssetsUnderManagementAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
}
