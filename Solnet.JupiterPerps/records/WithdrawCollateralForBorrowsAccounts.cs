using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record WithdrawCollateralForBorrowsAccounts
{
    public required PublicKey Owner { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey TransferAuthority { get; set; }
    public required PublicKey BorrowPosition { get; set; }
    public required PublicKey CollateralTokenAccount { get; set; }
    public required PublicKey UserTokenAccount { get; set; }
    public required PublicKey LpTokenMint { get; set; }
    public required PublicKey TokenProgram { get; set; }
    public required PublicKey EventAuthority { get; set; }
    public required PublicKey Program { get; set; }
}
