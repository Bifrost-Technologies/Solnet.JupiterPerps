using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class InstantCreateTpslParams
    {
        public ulong CollateralUsdDelta { get; set; }

        public ulong SizeUsdDelta { get; set; }

        public ulong TriggerPrice { get; set; }

        public bool TriggerAboveThreshold { get; set; }

        public bool EntirePosition { get; set; }

        public ulong Counter { get; set; }

        public long RequestTime { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(CollateralUsdDelta, offset);
            offset += 8;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU64(TriggerPrice, offset);
            offset += 8;
            _data.WriteBool(TriggerAboveThreshold, offset);
            offset += 1;
            _data.WriteBool(EntirePosition, offset);
            offset += 1;
            _data.WriteU64(Counter, offset);
            offset += 8;
            _data.WriteS64(RequestTime, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out InstantCreateTpslParams result)
        {
            int offset = initialOffset;
            result = new InstantCreateTpslParams();
            result.CollateralUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.TriggerPrice = _data.GetU64(offset);
            offset += 8;
            result.TriggerAboveThreshold = _data.GetBool(offset);
            offset += 1;
            result.EntirePosition = _data.GetBool(offset);
            offset += 1;
            result.Counter = _data.GetU64(offset);
            offset += 8;
            result.RequestTime = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
