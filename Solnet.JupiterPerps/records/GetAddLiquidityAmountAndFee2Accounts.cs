using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record GetAddLiquidityAmountAndFee2Accounts
{
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey CustodyDovesPriceAccount { get; set; }
    public required PublicKey CustodyPythnetPriceAccount { get; set; }
    public required PublicKey LpTokenMint { get; set; }
}
