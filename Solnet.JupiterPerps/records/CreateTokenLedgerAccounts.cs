using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record CreateTokenLedgerAccounts
{
    public required PublicKey TokenLedger { get; set; }
    public required PublicKey Payer { get; set; }
    public required PublicKey SystemProgram { get; set; }
}
