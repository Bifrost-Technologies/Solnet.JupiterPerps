using Solnet.Programs.Utilities;
using Solnet.Wallet;

namespace Solnet.JupiterPerps.Types
{
    public partial class AddCustodyParams
    {
        public bool IsStable { get; set; }

        public OracleParams? Oracle { get; set; }

        public PricingParams? Pricing { get; set; }

        public Permissions? Permissions { get; set; }

        public ulong HourlyFundingDbps { get; set; }

        public ulong TargetRatioBps { get; set; }

        public ulong IncreasePositionBps { get; set; }

        public ulong DecreasePositionBps { get; set; }

        public PublicKey? DovesOracle { get; set; }

        public ulong MaxPositionSizeUsd { get; set; }

        public JumpRateState? JumpRate { get; set; }

        public ulong PriceImpactFeeFactor { get; set; }

        public float PriceImpactExponent { get; set; }

        public ulong DeltaImbalanceThresholdDecimal { get; set; }

        public ulong MaxFeeBps { get; set; }

        public PublicKey? DovesAgOracle { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(IsStable, offset);
            offset += 1;
            offset += Oracle!.Serialize(_data, offset);
            offset += Pricing!.Serialize(_data, offset);
            offset += Permissions!.Serialize(_data, offset);
            _data.WriteU64(HourlyFundingDbps, offset);
            offset += 8;
            _data.WriteU64(TargetRatioBps, offset);
            offset += 8;
            _data.WriteU64(IncreasePositionBps, offset);
            offset += 8;
            _data.WriteU64(DecreasePositionBps, offset);
            offset += 8;
            _data.WritePubKey(DovesOracle, offset);
            offset += 32;
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
            _data.WritePubKey(DovesAgOracle, offset);
            offset += 32;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out AddCustodyParams result)
        {
            int offset = initialOffset;
            result = new AddCustodyParams();
            result.IsStable = _data.GetBool(offset);
            offset += 1;
            offset += OracleParams.Deserialize(_data, offset, out var resultOracle);
            result.Oracle = resultOracle;
            offset += PricingParams.Deserialize(_data, offset, out var resultPricing);
            result.Pricing = resultPricing;
            offset += Permissions.Deserialize(_data, offset, out var resultPermissions);
            result.Permissions = resultPermissions;
            result.HourlyFundingDbps = _data.GetU64(offset);
            offset += 8;
            result.TargetRatioBps = _data.GetU64(offset);
            offset += 8;
            result.IncreasePositionBps = _data.GetU64(offset);
            offset += 8;
            result.DecreasePositionBps = _data.GetU64(offset);
            offset += 8;
            result.DovesOracle = _data.GetPubKey(offset);
            offset += 32;
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
            result.DovesAgOracle = _data.GetPubKey(offset);
            offset += 32;
            return offset - initialOffset;
        }
    }
}
