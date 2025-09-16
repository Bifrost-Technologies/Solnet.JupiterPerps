using Solnet.Programs.Utilities;
using System.Numerics;

namespace Solnet.JupiterPerps.Types
{
    public partial class Limit
    {
        public BigInteger MaxAumUsd { get; set; }

        public BigInteger TokenWeightageBufferBps { get; set; }

        public ulong Buffer { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBigInt(MaxAumUsd, offset, 16, true);
            offset += 16;
            _data.WriteBigInt(TokenWeightageBufferBps, offset, 16, true);
            offset += 16;
            _data.WriteU64(Buffer, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Limit result)
        {
            int offset = initialOffset;
            result = new Limit();
            result.MaxAumUsd = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.TokenWeightageBufferBps = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.Buffer = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
