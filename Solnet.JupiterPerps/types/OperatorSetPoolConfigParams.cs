using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class OperatorSetPoolConfigParams
    {
        public Fees? Fees { get; set; }

        public Limit? Limit { get; set; }

        public long MaxRequestExecutionSec { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += Fees!.Serialize(_data, offset);
            offset += Limit!.Serialize(_data, offset);
            _data.WriteS64(MaxRequestExecutionSec, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out OperatorSetPoolConfigParams result)
        {
            int offset = initialOffset;
            result = new OperatorSetPoolConfigParams();
            offset += Fees.Deserialize(_data, offset, out var resultFees);
            result.Fees = resultFees;
            offset += Limit.Deserialize(_data, offset, out var resultLimit);
            result.Limit = resultLimit;
            result.MaxRequestExecutionSec = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
