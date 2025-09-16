using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class AddPoolParams
    {
        public string? Name { get; set; }

        public Limit? Limit { get; set; }

        public Fees? Fees { get; set; }

        public long MaxRequestExecutionSec { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += _data.WriteBorshString(Name, offset);
            offset += Limit!.Serialize(_data, offset);
            offset += Fees!.Serialize(_data, offset);
            _data.WriteS64(MaxRequestExecutionSec, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out AddPoolParams result)
        {
            int offset = initialOffset;
            result = new AddPoolParams();
            offset += _data.GetBorshString(offset, out var resultName);
            result.Name = resultName;
            offset += Limit.Deserialize(_data, offset, out var resultLimit);
            result.Limit = resultLimit;
            offset += Fees.Deserialize(_data, offset, out var resultFees);
            result.Fees = resultFees;
            result.MaxRequestExecutionSec = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
