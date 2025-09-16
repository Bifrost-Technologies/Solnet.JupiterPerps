using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record IncreasePositionPreSwapAccounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey KeeperAta { get; set; }
    public required PublicKey PositionRequest { get; set; }
    public required PublicKey PositionRequestAta { get; set; }
    public required PublicKey Position { get; set; }
    public required PublicKey CollateralCustody { get; set; }
    public required PublicKey CollateralCustodyTokenAccount { get; set; }
    public required PublicKey Instruction { get; set; }
    public required PublicKey TokenProgram { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
