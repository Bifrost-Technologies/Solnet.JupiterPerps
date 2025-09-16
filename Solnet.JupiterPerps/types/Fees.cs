using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class Fees
    {
        public ulong SwapMultiplier { get; set; }

        public ulong StableSwapMultiplier { get; set; }

        public ulong AddRemoveLiquidityBps { get; set; }

        public ulong SwapBps { get; set; }

        public ulong TaxBps { get; set; }

        public ulong StableSwapBps { get; set; }

        public ulong StableSwapTaxBps { get; set; }

        public ulong LiquidationRewardBps { get; set; }

        public ulong ProtocolShareBps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(SwapMultiplier, offset);
            offset += 8;
            _data.WriteU64(StableSwapMultiplier, offset);
            offset += 8;
            _data.WriteU64(AddRemoveLiquidityBps, offset);
            offset += 8;
            _data.WriteU64(SwapBps, offset);
            offset += 8;
            _data.WriteU64(TaxBps, offset);
            offset += 8;
            _data.WriteU64(StableSwapBps, offset);
            offset += 8;
            _data.WriteU64(StableSwapTaxBps, offset);
            offset += 8;
            _data.WriteU64(LiquidationRewardBps, offset);
            offset += 8;
            _data.WriteU64(ProtocolShareBps, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Fees result)
        {
            int offset = initialOffset;
            result = new Fees();
            result.SwapMultiplier = _data.GetU64(offset);
            offset += 8;
            result.StableSwapMultiplier = _data.GetU64(offset);
            offset += 8;
            result.AddRemoveLiquidityBps = _data.GetU64(offset);
            offset += 8;
            result.SwapBps = _data.GetU64(offset);
            offset += 8;
            result.TaxBps = _data.GetU64(offset);
            offset += 8;
            result.StableSwapBps = _data.GetU64(offset);
            offset += 8;
            result.StableSwapTaxBps = _data.GetU64(offset);
            offset += 8;
            result.LiquidationRewardBps = _data.GetU64(offset);
            offset += 8;
            result.ProtocolShareBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
