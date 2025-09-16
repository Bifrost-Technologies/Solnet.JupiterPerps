using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class OperatorSetCustodyConfigParams
    {
        public PricingParams? Pricing { get; set; }

        public ulong HourlyFundingDbps { get; set; }

        public ulong TargetRatioBps { get; set; }

        public ulong IncreasePositionBps { get; set; }

        public ulong DecreasePositionBps { get; set; }

        public ulong MaxPositionSizeUsd { get; set; }

        public JumpRateState? JumpRate { get; set; }

        public ulong PriceImpactFeeFactor { get; set; }

        public float PriceImpactExponent { get; set; }

        public ulong DeltaImbalanceThresholdDecimal { get; set; }

        public ulong MaxFeeBps { get; set; }

        public BorrowLendParams? BorrowLendParameters { get; set; }

        public ulong BorrowHourlyFundingDbps { get; set; }

        public ulong BorrowLimitInTokenAmount { get; set; }

        public ulong MinInterestFeeBps { get; set; }

        public ulong MinInterestFeeGracePeriodSeconds { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += Pricing!.Serialize(_data, offset);
            _data.WriteU64(HourlyFundingDbps, offset);
            offset += 8;
            _data.WriteU64(TargetRatioBps, offset);
            offset += 8;
            _data.WriteU64(IncreasePositionBps, offset);
            offset += 8;
            _data.WriteU64(DecreasePositionBps, offset);
            offset += 8;
            _data.WriteU64(MaxPositionSizeUsd, offset);
            offset += 8;
            offset += JumpRate!.Serialize(_data, offset);
            _data.WriteU64(PriceImpactFeeFactor, offset);
            offset += 8;
            _data.WriteSingle(PriceImpactExponent, offset);
            offset += 4;
            _data.WriteU64(DeltaImbalanceThresholdDecimal, offset);
            offset += 8;
            _data.WriteU64(MaxFeeBps, offset);
            offset += 8;
            offset += BorrowLendParameters!.Serialize(_data, offset);
            _data.WriteU64(BorrowHourlyFundingDbps, offset);
            offset += 8;
            _data.WriteU64(BorrowLimitInTokenAmount, offset);
            offset += 8;
            _data.WriteU64(MinInterestFeeBps, offset);
            offset += 8;
            _data.WriteU64(MinInterestFeeGracePeriodSeconds, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out OperatorSetCustodyConfigParams result)
        {
            int offset = initialOffset;
            result = new OperatorSetCustodyConfigParams();
            offset += PricingParams.Deserialize(_data, offset, out var resultPricing);
            result.Pricing = resultPricing;
            result.HourlyFundingDbps = _data.GetU64(offset);
            offset += 8;
            result.TargetRatioBps = _data.GetU64(offset);
            offset += 8;
            result.IncreasePositionBps = _data.GetU64(offset);
            offset += 8;
            result.DecreasePositionBps = _data.GetU64(offset);
            offset += 8;
            result.MaxPositionSizeUsd = _data.GetU64(offset);
            offset += 8;
            offset += JumpRateState.Deserialize(_data, offset, out var resultJumpRate);
            result.JumpRate = resultJumpRate;
            result.PriceImpactFeeFactor = _data.GetU64(offset);
            offset += 8;
            result.PriceImpactExponent = _data.GetSingle(offset);
            offset += 4;
            result.DeltaImbalanceThresholdDecimal = _data.GetU64(offset);
            offset += 8;
            result.MaxFeeBps = _data.GetU64(offset);
            offset += 8;
            offset += BorrowLendParams.Deserialize(_data, offset, out var resultBorrowLendParameters);
            result.BorrowLendParameters = resultBorrowLendParameters;
            result.BorrowHourlyFundingDbps = _data.GetU64(offset);
            offset += 8;
            result.BorrowLimitInTokenAmount = _data.GetU64(offset);
            offset += 8;
            result.MinInterestFeeBps = _data.GetU64(offset);
            offset += 8;
            result.MinInterestFeeGracePeriodSeconds = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
