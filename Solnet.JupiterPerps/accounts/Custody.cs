using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Numerics;

namespace Solnet.JupiterPerps
{
    public partial class Custody
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 10466228495849666561UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 1, 184, 48, 81, 93, 131, 63, 145 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "HgWVUrv1XE";
        public PublicKey? Pool { get; set; }

        public PublicKey? Mint { get; set; }

        public PublicKey? TokenAccount { get; set; }

        public byte Decimals { get; set; }

        public bool IsStable { get; set; }

        public OracleParams? Oracle { get; set; }

        public PricingParams? Pricing { get; set; }

        public Permissions? Permissions { get; set; }

        public ulong TargetRatioBps { get; set; }

        public Assets? Assets { get; set; }

        public FundingRateState? FundingRateState { get; set; }

        public byte Bump { get; set; }

        public byte TokenAccountBump { get; set; }

        public ulong IncreasePositionBps { get; set; }

        public ulong DecreasePositionBps { get; set; }

        public ulong MaxPositionSizeUsd { get; set; }

        public PublicKey? DovesOracle { get; set; }

        public JumpRateState? JumpRateState { get; set; }

        public PublicKey? DovesAgOracle { get; set; }

        public PriceImpactBuffer? PriceImpactBuffer { get; set; }

        public BorrowLendParams? BorrowLendParameters { get; set; }

        public FundingRateState? BorrowsFundingRateState { get; set; }

        public BigInteger Debt { get; set; }

        public BigInteger BorrowLendInterestsAccured { get; set; }

        public ulong BorrowLimitInTokenAmount { get; set; }

        public ulong MinInterestFeeBps { get; set; }

        public ulong MinInterestFeeGracePeriodSeconds { get; set; }

        public static Custody? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            Custody result = new Custody();
            result.Pool = _data.GetPubKey(offset);
            offset += 32;
            result.Mint = _data.GetPubKey(offset);
            offset += 32;
            result.TokenAccount = _data.GetPubKey(offset);
            offset += 32;
            result.Decimals = _data.GetU8(offset);
            offset += 1;
            result.IsStable = _data.GetBool(offset);
            offset += 1;
            offset += OracleParams.Deserialize(_data, offset, out var resultOracle);
            result.Oracle = resultOracle;
            offset += PricingParams.Deserialize(_data, offset, out var resultPricing);
            result.Pricing = resultPricing;
            offset += Permissions.Deserialize(_data, offset, out var resultPermissions);
            result.Permissions = resultPermissions;
            result.TargetRatioBps = _data.GetU64(offset);
            offset += 8;
            offset += Assets.Deserialize(_data, offset, out var resultAssets);
            result.Assets = resultAssets;
            offset += FundingRateState.Deserialize(_data, offset, out var resultFundingRateState);
            result.FundingRateState = resultFundingRateState;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            result.TokenAccountBump = _data.GetU8(offset);
            offset += 1;
            result.IncreasePositionBps = _data.GetU64(offset);
            offset += 8;
            result.DecreasePositionBps = _data.GetU64(offset);
            offset += 8;
            result.MaxPositionSizeUsd = _data.GetU64(offset);
            offset += 8;
            result.DovesOracle = _data.GetPubKey(offset);
            offset += 32;
            offset += JumpRateState.Deserialize(_data, offset, out var resultJumpRateState);
            result.JumpRateState = resultJumpRateState;
            result.DovesAgOracle = _data.GetPubKey(offset);
            offset += 32;
            offset += PriceImpactBuffer.Deserialize(_data, offset, out var resultPriceImpactBuffer);
            result.PriceImpactBuffer = resultPriceImpactBuffer;
            offset += BorrowLendParams.Deserialize(_data, offset, out var resultBorrowLendParameters);
            result.BorrowLendParameters = resultBorrowLendParameters;
            offset += FundingRateState.Deserialize(_data, offset, out var resultBorrowsFundingRateState);
            result.BorrowsFundingRateState = resultBorrowsFundingRateState;
            result.Debt = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.BorrowLendInterestsAccured = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.BorrowLimitInTokenAmount = _data.GetU64(offset);
            offset += 8;
            result.MinInterestFeeBps = _data.GetU64(offset);
            offset += 8;
            result.MinInterestFeeGracePeriodSeconds = _data.GetU64(offset);
            offset += 8;
            return result;
        }
    }
}
