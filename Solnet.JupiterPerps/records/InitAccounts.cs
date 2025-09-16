using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record InitAccounts
{
    public required PublicKey UpgradeAuthority { get; set; }
    public required PublicKey Admin { get; set; }
    public required PublicKey TransferAuthority { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey PerpetualsProgram { get; set; }
    public required PublicKey PerpetualsProgramData { get; set; }
    public required PublicKey SystemProgram { get; set; }
    public required PublicKey TokenProgram { get; set; }
}
