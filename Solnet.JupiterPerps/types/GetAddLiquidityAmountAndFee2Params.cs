using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class GetAddLiquidityAmountAndFee2Params
    {
        public ulong TokenAmountIn { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(TokenAmountIn, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetAddLiquidityAmountAndFee2Params result)
        {
            int offset = initialOffset;
            result = new GetAddLiquidityAmountAndFee2Params();
            result.TokenAmountIn = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
