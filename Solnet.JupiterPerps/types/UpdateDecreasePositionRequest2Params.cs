using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class UpdateDecreasePositionRequest2Params
    {
        public ulong SizeUsdDelta { get; set; }

        public ulong TriggerPrice { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU64(TriggerPrice, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateDecreasePositionRequest2Params result)
        {
            int offset = initialOffset;
            result = new UpdateDecreasePositionRequest2Params();
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.TriggerPrice = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
