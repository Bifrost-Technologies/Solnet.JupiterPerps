using Solnet.Programs.Utilities;
using System.Numerics;

namespace Solnet.JupiterPerps.Types
{
    public partial class FundingRateState
    {
        public BigInteger CumulativeInterestRate { get; set; }

        public long LastUpdate { get; set; }

        public ulong HourlyFundingDbps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBigInt(CumulativeInterestRate, offset, 16, true);
            offset += 16;
            _data.WriteS64(LastUpdate, offset);
            offset += 8;
            _data.WriteU64(HourlyFundingDbps, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out FundingRateState result)
        {
            int offset = initialOffset;
            result = new FundingRateState();
            result.CumulativeInterestRate = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.LastUpdate = _data.GetS64(offset);
            offset += 8;
            result.HourlyFundingDbps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
