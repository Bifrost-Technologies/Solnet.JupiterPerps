using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class GetRemoveLiquidityAmountAndFee2Params
    {
        public ulong LpAmountIn { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(LpAmountIn, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetRemoveLiquidityAmountAndFee2Params result)
        {
            int offset = initialOffset;
            result = new GetRemoveLiquidityAmountAndFee2Params();
            result.LpAmountIn = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
