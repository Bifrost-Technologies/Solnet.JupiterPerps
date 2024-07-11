
using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.JupiterPerps
{
    public partial class Custody
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 10466228495849666561UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 1, 184, 48, 81, 93, 131, 63, 145 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "HgWVUrv1XE";
        public PublicKey Pool { get; set; }

        public PublicKey Mint { get; set; }

        public PublicKey TokenAccount { get; set; }

        public byte Decimals { get; set; }

        public bool IsStable { get; set; }

        public OracleParams Oracle { get; set; }

        public PricingParams Pricing { get; set; }

        public Permissions Permissions { get; set; }

        public ulong TargetRatioBps { get; set; }

        public Assets Assets { get; set; }

        public FundingRateState FundingRateState { get; set; }

        public byte Bump { get; set; }

        public byte TokenAccountBump { get; set; }

        public static Custody Deserialize(ReadOnlySpan<byte> _data)
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
            return result;
        }
    }

    public partial class TestOracle
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 2065177405252645318UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 198, 49, 63, 134, 232, 251, 168, 28 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "a9iRwHPfAv7";
        public ulong Price { get; set; }

        public int Expo { get; set; }

        public ulong Conf { get; set; }

        public long PublishTime { get; set; }

        public static TestOracle Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            TestOracle result = new TestOracle();
            result.Price = _data.GetU64(offset);
            offset += 8;
            result.Expo = _data.GetS32(offset);
            offset += 4;
            result.Conf = _data.GetU64(offset);
            offset += 8;
            result.PublishTime = _data.GetS64(offset);
            offset += 8;
            return result;
        }
    }

    public partial class Perpetuals
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 14153778338759616284UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 28, 167, 98, 191, 104, 82, 108, 196 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "5nyjp1aZDB1";
        public Permissions Permissions { get; set; }

        public PublicKey[] Pools { get; set; }

        public PublicKey Admin { get; set; }

        public byte TransferAuthorityBump { get; set; }

        public byte PerpetualsBump { get; set; }

        public long InceptionTime { get; set; }

        public static Perpetuals Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            Perpetuals result = new Perpetuals();
            offset += Permissions.Deserialize(_data, offset, out var resultPermissions);
            result.Permissions = resultPermissions;
            int resultPoolsLength = (int)_data.GetU32(offset);
            offset += 4;
            result.Pools = new PublicKey[resultPoolsLength];
            for (uint resultPoolsIdx = 0; resultPoolsIdx < resultPoolsLength; resultPoolsIdx++)
            {
                result.Pools[resultPoolsIdx] = _data.GetPubKey(offset);
                offset += 32;
            }

            result.Admin = _data.GetPubKey(offset);
            offset += 32;
            result.TransferAuthorityBump = _data.GetU8(offset);
            offset += 1;
            result.PerpetualsBump = _data.GetU8(offset);
            offset += 1;
            result.InceptionTime = _data.GetS64(offset);
            offset += 8;
            return result;
        }
    }

    public partial class Pool
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 13577703138238765809UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 241, 154, 109, 4, 17, 177, 109, 188 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "hQrXeCntzbV";
        public string Name { get; set; }

        public PublicKey[] Custodies { get; set; }

        public BigInteger AumUsd { get; set; }

        public Limit Limit { get; set; }

        public Fees Fees { get; set; }

        public PoolApr PoolApr { get; set; }

        public long MaxRequestExecutionSec { get; set; }

        public byte Bump { get; set; }

        public byte LpTokenBump { get; set; }

        public long InceptionTime { get; set; }

        public static Pool Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            Pool result = new Pool();
            offset += _data.GetBorshString(offset, out var resultName);
            result.Name = resultName;
            int resultCustodiesLength = (int)_data.GetU32(offset);
            offset += 4;
            result.Custodies = new PublicKey[resultCustodiesLength];
            for (uint resultCustodiesIdx = 0; resultCustodiesIdx < resultCustodiesLength; resultCustodiesIdx++)
            {
                result.Custodies[resultCustodiesIdx] = _data.GetPubKey(offset);
                offset += 32;
            }

            result.AumUsd = _data.GetBigInt(offset, 16, false);
            offset += 16;
            offset += Limit.Deserialize(_data, offset, out var resultLimit);
            result.Limit = resultLimit;
            offset += Fees.Deserialize(_data, offset, out var resultFees);
            result.Fees = resultFees;
            offset += PoolApr.Deserialize(_data, offset, out var resultPoolApr);
            result.PoolApr = resultPoolApr;
            result.MaxRequestExecutionSec = _data.GetS64(offset);
            offset += 8;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            result.LpTokenBump = _data.GetU8(offset);
            offset += 1;
            result.InceptionTime = _data.GetS64(offset);
            offset += 8;
            return result;
        }
    }

    public partial class PositionRequest
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 15573617037161408012UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 12, 38, 250, 199, 46, 154, 32, 216 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "32tkJosYU3Z";
        public PublicKey Owner { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Mint { get; set; }

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

        public PublicKey Referral { get; set; }

        public static PositionRequest Deserialize(ReadOnlySpan<byte> _data)
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

    public partial class Position
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 15057574775701355690UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 170, 188, 143, 228, 122, 64, 247, 208 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "VZMoMoKgZQb";
        public PublicKey Owner { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public long OpenTime { get; set; }

        public long UpdateTime { get; set; }

        public Side Side { get; set; }

        public ulong Price { get; set; }

        public ulong SizeUsd { get; set; }

        public ulong CollateralUsd { get; set; }

        public long RealisedPnlUsd { get; set; }

        public BigInteger CumulativeInterestSnapshot { get; set; }

        public ulong LockedAmount { get; set; }

        public byte Bump { get; set; }

        public static Position Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            Position result = new Position();
            result.Owner = _data.GetPubKey(offset);
            offset += 32;
            result.Pool = _data.GetPubKey(offset);
            offset += 32;
            result.Custody = _data.GetPubKey(offset);
            offset += 32;
            result.CollateralCustody = _data.GetPubKey(offset);
            offset += 32;
            result.OpenTime = _data.GetS64(offset);
            offset += 8;
            result.UpdateTime = _data.GetS64(offset);
            offset += 8;
            result.Side = (Side)_data.GetU8(offset);
            offset += 1;
            result.Price = _data.GetU64(offset);
            offset += 8;
            result.SizeUsd = _data.GetU64(offset);
            offset += 8;
            result.CollateralUsd = _data.GetU64(offset);
            offset += 8;
            result.RealisedPnlUsd = _data.GetS64(offset);
            offset += 8;
            result.CumulativeInterestSnapshot = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.LockedAmount = _data.GetU64(offset);
            offset += 8;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            return result;
        }
    }
}
