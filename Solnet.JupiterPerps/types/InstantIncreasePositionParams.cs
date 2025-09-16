using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class InstantIncreasePositionParams
    {
        public ulong SizeUsdDelta { get; set; }

        public ulong? CollateralTokenDelta { get; set; }

        public Side Side { get; set; }

        public ulong PriceSlippage { get; set; }

        public long RequestTime { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            if (CollateralTokenDelta != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(CollateralTokenDelta.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            _data.WriteU8((byte)Side, offset);
            offset += 1;
            _data.WriteU64(PriceSlippage, offset);
            offset += 8;
            _data.WriteS64(RequestTime, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out InstantIncreasePositionParams result)
        {
            int offset = initialOffset;
            result = new InstantIncreasePositionParams();
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            if (_data.GetBool(offset++))
            {
                result.CollateralTokenDelta = _data.GetU64(offset);
                offset += 8;
            }

            result.Side = (Side)_data.GetU8(offset);
            offset += 1;
            result.PriceSlippage = _data.GetU64(offset);
            offset += 8;
            result.RequestTime = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
