using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System.Numerics;

namespace Solnet.JupiterPerps.Types
{
    public partial class AddLiquidity2Params
    {
        public ulong TokenAmountIn { get; set; }

        public ulong MinLpAmountOut { get; set; }

        public ulong? TokenAmountPreSwap { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(TokenAmountIn, offset);
            offset += 8;
            _data.WriteU64(MinLpAmountOut, offset);
            offset += 8;
            if (TokenAmountPreSwap != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(TokenAmountPreSwap.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out AddLiquidity2Params result)
        {
            int offset = initialOffset;
            result = new AddLiquidity2Params();
            result.TokenAmountIn = _data.GetU64(offset);
            offset += 8;
            result.MinLpAmountOut = _data.GetU64(offset);
            offset += 8;
            if (_data.GetBool(offset++))
            {
                result.TokenAmountPreSwap = _data.GetU64(offset);
                offset += 8;
            }

            return offset - initialOffset;
        }
    }
}
