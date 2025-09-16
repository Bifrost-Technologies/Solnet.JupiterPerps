using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class Assets
    {
        public ulong FeesReserves { get; set; }

        public ulong Owned { get; set; }

        public ulong Locked { get; set; }

        public ulong GuaranteedUsd { get; set; }

        public ulong GlobalShortSizes { get; set; }

        public ulong GlobalShortAveragePrices { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(FeesReserves, offset);
            offset += 8;
            _data.WriteU64(Owned, offset);
            offset += 8;
            _data.WriteU64(Locked, offset);
            offset += 8;
            _data.WriteU64(GuaranteedUsd, offset);
            offset += 8;
            _data.WriteU64(GlobalShortSizes, offset);
            offset += 8;
            _data.WriteU64(GlobalShortAveragePrices, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Assets result)
        {
            int offset = initialOffset;
            result = new Assets();
            result.FeesReserves = _data.GetU64(offset);
            offset += 8;
            result.Owned = _data.GetU64(offset);
            offset += 8;
            result.Locked = _data.GetU64(offset);
            offset += 8;
            result.GuaranteedUsd = _data.GetU64(offset);
            offset += 8;
            result.GlobalShortSizes = _data.GetU64(offset);
            offset += 8;
            result.GlobalShortAveragePrices = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
