using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class CreateDecreasePositionRequest2Params
    {
        public ulong CollateralUsdDelta { get; set; }

        public ulong SizeUsdDelta { get; set; }

        public RequestType RequestType { get; set; }

        public ulong? PriceSlippage { get; set; }

        public ulong? JupiterMinimumOut { get; set; }

        public ulong? TriggerPrice { get; set; }

        public bool? TriggerAboveThreshold { get; set; }

        public bool? EntirePosition { get; set; }

        public ulong Counter { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(CollateralUsdDelta, offset);
            offset += 8;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU8((byte)RequestType, offset);
            offset += 1;
            if (PriceSlippage != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(PriceSlippage.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (JupiterMinimumOut != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(JupiterMinimumOut.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (TriggerPrice != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(TriggerPrice.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (TriggerAboveThreshold != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteBool(TriggerAboveThreshold.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (EntirePosition != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteBool(EntirePosition.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            _data.WriteU64(Counter, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CreateDecreasePositionRequest2Params result)
        {
            int offset = initialOffset;
            result = new CreateDecreasePositionRequest2Params();
            result.CollateralUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.RequestType = (RequestType)_data.GetU8(offset);
            offset += 1;
            if (_data.GetBool(offset++))
            {
                result.PriceSlippage = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.JupiterMinimumOut = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.TriggerPrice = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.TriggerAboveThreshold = _data.GetBool(offset);
                offset += 1;
            }

            if (_data.GetBool(offset++))
            {
                result.EntirePosition = _data.GetBool(offset);
                offset += 1;
            }

            result.Counter = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
