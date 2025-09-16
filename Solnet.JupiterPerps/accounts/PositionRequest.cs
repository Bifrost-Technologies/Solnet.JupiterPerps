using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;

namespace Solnet.JupiterPerps
{
    public partial class PositionRequest
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 15573617037161408012UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 12, 38, 250, 199, 46, 154, 32, 216 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "32tkJosYU3Z";
        public PublicKey? Owner { get; set; }

        public PublicKey? Pool { get; set; }

        public PublicKey? Custody { get; set; }

        public PublicKey? Position { get; set; }

        public PublicKey? Mint { get; set; }

        public long OpenTime { get; set; }

        public long UpdateTime { get; set; }

        public ulong SizeUsdDelta { get; set; }

        public ulong CollateralDelta { get; set; }

        public RequestChange RequestChange { get; set; }

        public RequestType RequestType { get; set; }

        public Side Side { get; set; }

        public ulong? PriceSlippage { get; set; }

        public ulong? JupiterMinimumOut { get; set; }

        public ulong? PreSwapAmount { get; set; }

        public ulong? TriggerPrice { get; set; }

        public bool? TriggerAboveThreshold { get; set; }

        public bool? EntirePosition { get; set; }

        public bool Executed { get; set; }

        public ulong Counter { get; set; }

        public byte Bump { get; set; }

        public PublicKey? Referral { get; set; }

        public static PositionRequest? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            PositionRequest result = new PositionRequest();
            result.Owner = _data.GetPubKey(offset);
            offset += 32;
            result.Pool = _data.GetPubKey(offset);
            offset += 32;
            result.Custody = _data.GetPubKey(offset);
            offset += 32;
            result.Position = _data.GetPubKey(offset);
            offset += 32;
            result.Mint = _data.GetPubKey(offset);
            offset += 32;
            result.OpenTime = _data.GetS64(offset);
            offset += 8;
            result.UpdateTime = _data.GetS64(offset);
            offset += 8;
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.CollateralDelta = _data.GetU64(offset);
            offset += 8;
            result.RequestChange = (RequestChange)_data.GetU8(offset);
            offset += 1;
            result.RequestType = (RequestType)_data.GetU8(offset);
            offset += 1;
            result.Side = (Side)_data.GetU8(offset);
            offset += 1;
            if (_data.GetBool(offset++))
            {
                result.PriceSlippage = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.JupiterMinimumOut = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.PreSwapAmount = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.TriggerPrice = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.TriggerAboveThreshold = _data.GetBool(offset);
                offset += 1;
            }

            if (_data.GetBool(offset++))
            {
                result.EntirePosition = _data.GetBool(offset);
                offset += 1;
            }

            result.Executed = _data.GetBool(offset);
            offset += 1;
            result.Counter = _data.GetU64(offset);
            offset += 8;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            if (_data.GetBool(offset++))
            {
                result.Referral = _data.GetPubKey(offset);
                offset += 32;
            }

            return result;
        }
    }
}
