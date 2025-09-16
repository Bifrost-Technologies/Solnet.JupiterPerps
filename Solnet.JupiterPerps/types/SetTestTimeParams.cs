using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class SetTestTimeParams
    {
        public long Time { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteS64(Time, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetTestTimeParams result)
        {
            int offset = initialOffset;
            result = new SetTestTimeParams();
            result.Time = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
