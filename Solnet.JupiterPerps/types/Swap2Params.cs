using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class Swap2Params
    {
        public ulong AmountIn { get; set; }

        public ulong MinAmountOut { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(AmountIn, offset);
            offset += 8;
            _data.WriteU64(MinAmountOut, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Swap2Params result)
        {
            int offset = initialOffset;
            result = new Swap2Params();
            result.AmountIn = _data.GetU64(offset);
            offset += 8;
            result.MinAmountOut = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
