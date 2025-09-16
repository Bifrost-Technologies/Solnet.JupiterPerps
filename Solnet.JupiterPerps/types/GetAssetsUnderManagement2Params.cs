using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class GetAssetsUnderManagement2Params
    {
        public PriceCalcMode? Mode { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            if (Mode != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU8((byte)Mode, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetAssetsUnderManagement2Params result)
        {
            int offset = initialOffset;
            result = new GetAssetsUnderManagement2Params();
            if (_data.GetBool(offset++))
            {
                result.Mode = (PriceCalcMode)_data.GetU8(offset);
                offset += 1;
            }

            return offset - initialOffset;
        }
    }
}
