using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class JumpRateState
    {
        public ulong MinRateBps { get; set; }

        public ulong MaxRateBps { get; set; }

        public ulong TargetRateBps { get; set; }

        public ulong TargetUtilizationRate { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(MinRateBps, offset);
            offset += 8;
            _data.WriteU64(MaxRateBps, offset);
            offset += 8;
            _data.WriteU64(TargetRateBps, offset);
            offset += 8;
            _data.WriteU64(TargetUtilizationRate, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out JumpRateState result)
        {
            int offset = initialOffset;
            result = new JumpRateState();
            result.MinRateBps = _data.GetU64(offset);
            offset += 8;
            result.MaxRateBps = _data.GetU64(offset);
            offset += 8;
            result.TargetRateBps = _data.GetU64(offset);
            offset += 8;
            result.TargetUtilizationRate = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
