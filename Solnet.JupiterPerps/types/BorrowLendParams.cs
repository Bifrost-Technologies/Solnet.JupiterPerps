using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class BorrowLendParams
    {
        public ulong BorrowsLimitInBps { get; set; }

        public ulong MaintainanceMarginBps { get; set; }

        public ulong ProtocolFeeBps { get; set; }

        public ulong LiquidationMargin { get; set; }

        public ulong LiquidationFeeBps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(BorrowsLimitInBps, offset);
            offset += 8;
            _data.WriteU64(MaintainanceMarginBps, offset);
            offset += 8;
            _data.WriteU64(ProtocolFeeBps, offset);
            offset += 8;
            _data.WriteU64(LiquidationMargin, offset);
            offset += 8;
            _data.WriteU64(LiquidationFeeBps, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out BorrowLendParams result)
        {
            int offset = initialOffset;
            result = new BorrowLendParams();
            result.BorrowsLimitInBps = _data.GetU64(offset);
            offset += 8;
            result.MaintainanceMarginBps = _data.GetU64(offset);
            offset += 8;
            result.ProtocolFeeBps = _data.GetU64(offset);
            offset += 8;
            result.LiquidationMargin = _data.GetU64(offset);
            offset += 8;
            result.LiquidationFeeBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
