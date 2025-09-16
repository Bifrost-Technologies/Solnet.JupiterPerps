using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class PriceImpactBuffer
    {
        public long[]? OpenInterest { get; set; }

        public long LastUpdated { get; set; }

        public ulong FeeFactor { get; set; }

        public float Exponent { get; set; }

        public ulong DeltaImbalanceThresholdDecimal { get; set; }

        public ulong MaxFeeBps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            foreach (var openInterestElement in OpenInterest!)
            {
                _data.WriteS64(openInterestElement, offset);
                offset += 8;
            }

            _data.WriteS64(LastUpdated, offset);
            offset += 8;
            _data.WriteU64(FeeFactor, offset);
            offset += 8;
            _data.WriteSingle(Exponent, offset);
            offset += 4;
            _data.WriteU64(DeltaImbalanceThresholdDecimal, offset);
            offset += 8;
            _data.WriteU64(MaxFeeBps, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PriceImpactBuffer result)
        {
            int offset = initialOffset;
            result = new PriceImpactBuffer();
            result.OpenInterest = new long[60];
            for (uint resultOpenInterestIdx = 0; resultOpenInterestIdx < 60; resultOpenInterestIdx++)
            {
                result.OpenInterest[resultOpenInterestIdx] = _data.GetS64(offset);
                offset += 8;
            }

            result.LastUpdated = _data.GetS64(offset);
            offset += 8;
            result.FeeFactor = _data.GetU64(offset);
            offset += 8;
            result.Exponent = _data.GetSingle(offset);
            offset += 4;
            result.DeltaImbalanceThresholdDecimal = _data.GetU64(offset);
            offset += 8;
            result.MaxFeeBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
