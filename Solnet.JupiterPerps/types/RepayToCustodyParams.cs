using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class RepayToCustodyParams
    {
        public ulong Amount { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(Amount, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out RepayToCustodyParams result)
        {
            int offset = initialOffset;
            result = new RepayToCustodyParams();
            result.Amount = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
