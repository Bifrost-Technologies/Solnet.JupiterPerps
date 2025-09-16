using Solnet.Wallet;

namespace Solnet.JupiterPerps.Records;

public record UpdateDecreasePositionRequest2Accounts
{
    public required PublicKey Owner { get; set; }
    public required PublicKey Perpetuals { get; set; }
    public required PublicKey Pool { get; set; }
    public required PublicKey Position { get; set; }
    public required PublicKey PositionRequest { get; set; }
    public required PublicKey Custody { get; set; }
    public required PublicKey CustodyDovesPriceAccount { get; set; }
    public required PublicKey CustodyPythnetPriceAccount { get; set; }
}
