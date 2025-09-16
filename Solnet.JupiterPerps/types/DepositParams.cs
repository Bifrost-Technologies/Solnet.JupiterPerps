using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class DepositParams
    {
        public ulong Amount { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(Amount, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out DepositParams result)
        {
            int offset = initialOffset;
            result = new DepositParams();
            result.Amount = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
