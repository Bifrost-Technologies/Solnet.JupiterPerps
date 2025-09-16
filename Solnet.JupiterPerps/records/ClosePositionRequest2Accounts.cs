using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record ClosePositionRequest2Accounts
{
    public required PublicKey Keeper { get; set; }
    public required PublicKey Owner { get; set; }
    public required PublicKey OwnerAta { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey PositionRequest { get; set; }
    public required PublicKey PositionRequestAta { get; set; }
    public required PublicKey Position { get; set; }
    public required PublicKey Mint { get; set; }
    public required PublicKey TokenProgram { get; set; }
    public required PublicKey SystemProgram { get; set; }
    public required PublicKey AssociatedTokenProgram { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
