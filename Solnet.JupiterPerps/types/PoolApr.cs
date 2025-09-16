using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class PoolApr
    {
        public long LastUpdated { get; set; }

        public ulong FeeAprBps { get; set; }

        public ulong RealizedFeeUsd { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteS64(LastUpdated, offset);
            offset += 8;
            _data.WriteU64(FeeAprBps, offset);
            offset += 8;
            _data.WriteU64(RealizedFeeUsd, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PoolApr result)
        {
            int offset = initialOffset;
            result = new PoolApr();
            result.LastUpdated = _data.GetS64(offset);
            offset += 8;
            result.FeeAprBps = _data.GetU64(offset);
            offset += 8;
            result.RealizedFeeUsd = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
