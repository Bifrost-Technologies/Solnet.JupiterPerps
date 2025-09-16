using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record CloseBorrowPositionAccounts
{
    public required PublicKey Owner { get; set; }
    public required PublicKey BorrowPosition { get; set; }
    public required PublicKey SystemProgram { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
