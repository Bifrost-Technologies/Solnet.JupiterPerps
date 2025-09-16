using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class PricingParams
    {
        public ulong TradeImpactFeeScalar { get; set; }

        public ulong Buffer { get; set; }

        public ulong SwapSpread { get; set; }

        public ulong MaxLeverage { get; set; }

        public ulong MaxGlobalLongSizes { get; set; }

        public ulong MaxGlobalShortSizes { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(TradeImpactFeeScalar, offset);
            offset += 8;
            _data.WriteU64(Buffer, offset);
            offset += 8;
            _data.WriteU64(SwapSpread, offset);
            offset += 8;
            _data.WriteU64(MaxLeverage, offset);
            offset += 8;
            _data.WriteU64(MaxGlobalLongSizes, offset);
            offset += 8;
            _data.WriteU64(MaxGlobalShortSizes, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PricingParams result)
        {
            int offset = initialOffset;
            result = new PricingParams();
            result.TradeImpactFeeScalar = _data.GetU64(offset);
            offset += 8;
            result.Buffer = _data.GetU64(offset);
            offset += 8;
            result.SwapSpread = _data.GetU64(offset);
            offset += 8;
            result.MaxLeverage = _data.GetU64(offset);
            offset += 8;
            result.MaxGlobalLongSizes = _data.GetU64(offset);
            offset += 8;
            result.MaxGlobalShortSizes = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
