using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record SetTokenLedgerAccounts
{
    public required PublicKey TokenLedger { get; set; }
    public required PublicKey TokenAccount { get; set; }
    public required PublicKey TokenProgram { get; set; }
}
