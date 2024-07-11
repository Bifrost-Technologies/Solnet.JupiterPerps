using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System.Numerics;


namespace Solnet.JupiterPerps.Types
{
    public partial class AddCustodyParams
    {
        public bool IsStable { get; set; }

        public OracleParams Oracle { get; set; }

        public PricingParams Pricing { get; set; }

        public Permissions Permissions { get; set; }

        public ulong HourlyFundingBps { get; set; }

        public ulong TargetRatioBps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(IsStable, offset);
            offset += 1;
            offset += Oracle.Serialize(_data, offset);
            offset += Pricing.Serialize(_data, offset);
            offset += Permissions.Serialize(_data, offset);
            _data.WriteU64(HourlyFundingBps, offset);
            offset += 8;
            _data.WriteU64(TargetRatioBps, offset);
            offset += 8;
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
            result.HourlyFundingBps = _data.GetU64(offset);
            offset += 8;
            result.TargetRatioBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class AddLiquidityParams
    {
        public ulong TokenAmountIn { get; set; }

        public ulong MinLpAmountOut { get; set; }

        public ulong? TokenAmountPreSwap { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(TokenAmountIn, offset);
            offset += 8;
            _data.WriteU64(MinLpAmountOut, offset);
            offset += 8;
            if (TokenAmountPreSwap != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(TokenAmountPreSwap.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out AddLiquidityParams result)
        {
            int offset = initialOffset;
            result = new AddLiquidityParams();
            result.TokenAmountIn = _data.GetU64(offset);
            offset += 8;
            result.MinLpAmountOut = _data.GetU64(offset);
            offset += 8;
            if (_data.GetBool(offset++))
            {
                result.TokenAmountPreSwap = _data.GetU64(offset);
                offset += 8;
            }

            return offset - initialOffset;
        }
    }

    public partial class AddPoolParams
    {
        public string Name { get; set; }

        public Limit Limit { get; set; }

        public Fees Fees { get; set; }

        public long MaxRequestExecutionSec { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += _data.WriteBorshString(Name, offset);
            offset += Limit.Serialize(_data, offset);
            offset += Fees.Serialize(_data, offset);
            _data.WriteS64(MaxRequestExecutionSec, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out AddPoolParams result)
        {
            int offset = initialOffset;
            result = new AddPoolParams();
            offset += _data.GetBorshString(offset, out var resultName);
            result.Name = resultName;
            offset += Limit.Deserialize(_data, offset, out var resultLimit);
            result.Limit = resultLimit;
            offset += Fees.Deserialize(_data, offset, out var resultFees);
            result.Fees = resultFees;
            result.MaxRequestExecutionSec = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class ClosePositionRequestParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out ClosePositionRequestParams result)
        {
            int offset = initialOffset;
            result = new ClosePositionRequestParams();
            return offset - initialOffset;
        }
    }

    public partial class CreateDecreasePositionMarketRequestParams
    {
        public ulong CollateralUsdDelta { get; set; }

        public ulong SizeUsdDelta { get; set; }

        public ulong PriceSlippage { get; set; }

        public ulong? JupiterMinimumOut { get; set; }

        public bool? EntirePosition { get; set; }

        public ulong Counter { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(CollateralUsdDelta, offset);
            offset += 8;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU64(PriceSlippage, offset);
            offset += 8;
            if (JupiterMinimumOut != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(JupiterMinimumOut.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (EntirePosition != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteBool(EntirePosition.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            _data.WriteU64(Counter, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CreateDecreasePositionMarketRequestParams result)
        {
            int offset = initialOffset;
            result = new CreateDecreasePositionMarketRequestParams();
            result.CollateralUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.PriceSlippage = _data.GetU64(offset);
            offset += 8;
            if (_data.GetBool(offset++))
            {
                result.JupiterMinimumOut = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.EntirePosition = _data.GetBool(offset);
                offset += 1;
            }

            result.Counter = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class CreateDecreasePositionRequestParams
    {
        public ulong CollateralUsdDelta { get; set; }

        public ulong SizeUsdDelta { get; set; }

        public RequestType RequestType { get; set; }

        public ulong? PriceSlippage { get; set; }

        public ulong? JupiterMinimumOut { get; set; }

        public ulong? TriggerPrice { get; set; }

        public bool? TriggerAboveThreshold { get; set; }

        public bool? EntirePosition { get; set; }

        public ulong Counter { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(CollateralUsdDelta, offset);
            offset += 8;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU8((byte)RequestType, offset);
            offset += 1;
            if (PriceSlippage != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(PriceSlippage.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (JupiterMinimumOut != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(JupiterMinimumOut.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (TriggerPrice != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(TriggerPrice.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (TriggerAboveThreshold != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteBool(TriggerAboveThreshold.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (EntirePosition != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteBool(EntirePosition.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            _data.WriteU64(Counter, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CreateDecreasePositionRequestParams result)
        {
            int offset = initialOffset;
            result = new CreateDecreasePositionRequestParams();
            result.CollateralUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.RequestType = (RequestType)_data.GetU8(offset);
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

            result.Counter = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class CreateIncreasePositionMarketRequestParams
    {
        public ulong SizeUsdDelta { get; set; }

        public ulong CollateralTokenDelta { get; set; }

        public Side Side { get; set; }

        public ulong PriceSlippage { get; set; }

        public ulong? JupiterMinimumOut { get; set; }

        public ulong Counter { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU64(CollateralTokenDelta, offset);
            offset += 8;
            _data.WriteU8((byte)Side, offset);
            offset += 1;
            _data.WriteU64(PriceSlippage, offset);
            offset += 8;
            if (JupiterMinimumOut != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(JupiterMinimumOut.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            _data.WriteU64(Counter, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CreateIncreasePositionMarketRequestParams result)
        {
            int offset = initialOffset;
            result = new CreateIncreasePositionMarketRequestParams();
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.CollateralTokenDelta = _data.GetU64(offset);
            offset += 8;
            result.Side = (Side)_data.GetU8(offset);
            offset += 1;
            result.PriceSlippage = _data.GetU64(offset);
            offset += 8;
            if (_data.GetBool(offset++))
            {
                result.JupiterMinimumOut = _data.GetU64(offset);
                offset += 8;
            }

            result.Counter = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class CreateIncreasePositionRequestParams
    {
        public ulong SizeUsdDelta { get; set; }

        public ulong CollateralTokenDelta { get; set; }

        public Side Side { get; set; }

        public RequestType RequestType { get; set; }

        public ulong? PriceSlippage { get; set; }

        public ulong? JupiterMinimumOut { get; set; }

        public ulong? TriggerPrice { get; set; }

        public bool? TriggerAboveThreshold { get; set; }

        public ulong Counter { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU64(CollateralTokenDelta, offset);
            offset += 8;
            _data.WriteU8((byte)Side, offset);
            offset += 1;
            _data.WriteU8((byte)RequestType, offset);
            offset += 1;
            if (PriceSlippage != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(PriceSlippage.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (JupiterMinimumOut != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(JupiterMinimumOut.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (TriggerPrice != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(TriggerPrice.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (TriggerAboveThreshold != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteBool(TriggerAboveThreshold.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            _data.WriteU64(Counter, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CreateIncreasePositionRequestParams result)
        {
            int offset = initialOffset;
            result = new CreateIncreasePositionRequestParams();
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.CollateralTokenDelta = _data.GetU64(offset);
            offset += 8;
            result.Side = (Side)_data.GetU8(offset);
            offset += 1;
            result.RequestType = (RequestType)_data.GetU8(offset);
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
                result.TriggerPrice = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.TriggerAboveThreshold = _data.GetBool(offset);
                offset += 1;
            }

            result.Counter = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class CreateTokenMetadataParams
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Uri { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += _data.WriteBorshString(Name, offset);
            offset += _data.WriteBorshString(Symbol, offset);
            offset += _data.WriteBorshString(Uri, offset);
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CreateTokenMetadataParams result)
        {
            int offset = initialOffset;
            result = new CreateTokenMetadataParams();
            offset += _data.GetBorshString(offset, out var resultName);
            result.Name = resultName;
            offset += _data.GetBorshString(offset, out var resultSymbol);
            result.Symbol = resultSymbol;
            offset += _data.GetBorshString(offset, out var resultUri);
            result.Uri = resultUri;
            return offset - initialOffset;
        }
    }

    public partial class DecreasePosition2Params
    {
        public bool UsePriceUpdate { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(UsePriceUpdate, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out DecreasePosition2Params result)
        {
            int offset = initialOffset;
            result = new DecreasePosition2Params();
            result.UsePriceUpdate = _data.GetBool(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class DecreasePositionPostSwapParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out DecreasePositionPostSwapParams result)
        {
            int offset = initialOffset;
            result = new DecreasePositionPostSwapParams();
            return offset - initialOffset;
        }
    }

    public partial class GetAddLiquidityAmountAndFeeParams
    {
        public ulong TokenAmountIn { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(TokenAmountIn, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetAddLiquidityAmountAndFeeParams result)
        {
            int offset = initialOffset;
            result = new GetAddLiquidityAmountAndFeeParams();
            result.TokenAmountIn = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class GetAssetsUnderManagementParams
    {
        public PriceCalcMode Mode { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            if (Mode != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU8((byte)Mode, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetAssetsUnderManagementParams result)
        {
            int offset = initialOffset;
            result = new GetAssetsUnderManagementParams();
            if (_data.GetBool(offset++))
            {
                result.Mode = (PriceCalcMode)_data.GetU8(offset);
                offset += 1;
            }

            return offset - initialOffset;
        }
    }

    public partial class GetDecreasePositionParams
    {
        public ulong CollateralUsdDelta { get; set; }

        public ulong SizeUsdDelta { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(CollateralUsdDelta, offset);
            offset += 8;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetDecreasePositionParams result)
        {
            int offset = initialOffset;
            result = new GetDecreasePositionParams();
            result.CollateralUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class GetExactOutSwapAmountAndFeesParams
    {
        public ulong AmountOut { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(AmountOut, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetExactOutSwapAmountAndFeesParams result)
        {
            int offset = initialOffset;
            result = new GetExactOutSwapAmountAndFeesParams();
            result.AmountOut = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class GetIncreasePositionParams
    {
        public ulong CollateralTokenDelta { get; set; }

        public ulong SizeUsdDelta { get; set; }

        public Side Side { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(CollateralTokenDelta, offset);
            offset += 8;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU8((byte)Side, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetIncreasePositionParams result)
        {
            int offset = initialOffset;
            result = new GetIncreasePositionParams();
            result.CollateralTokenDelta = _data.GetU64(offset);
            offset += 8;
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.Side = (Side)_data.GetU8(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class GetLiquidationStateParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetLiquidationStateParams result)
        {
            int offset = initialOffset;
            result = new GetLiquidationStateParams();
            return offset - initialOffset;
        }
    }

    public partial class GetPnlAndFeeParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetPnlAndFeeParams result)
        {
            int offset = initialOffset;
            result = new GetPnlAndFeeParams();
            return offset - initialOffset;
        }
    }

    public partial class GetRemoveLiquidityAmountAndFeeParams
    {
        public ulong LpAmountIn { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(LpAmountIn, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetRemoveLiquidityAmountAndFeeParams result)
        {
            int offset = initialOffset;
            result = new GetRemoveLiquidityAmountAndFeeParams();
            result.LpAmountIn = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class GetSwapAmountAndFeesParams
    {
        public ulong AmountIn { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(AmountIn, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out GetSwapAmountAndFeesParams result)
        {
            int offset = initialOffset;
            result = new GetSwapAmountAndFeesParams();
            result.AmountIn = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class IncreasePosition2Params
    {
        public bool UsePriceUpdate { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(UsePriceUpdate, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out IncreasePosition2Params result)
        {
            int offset = initialOffset;
            result = new IncreasePosition2Params();
            result.UsePriceUpdate = _data.GetBool(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class IncreasePositionPreSwapParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out IncreasePositionPreSwapParams result)
        {
            int offset = initialOffset;
            result = new IncreasePositionPreSwapParams();
            return offset - initialOffset;
        }
    }

    public partial class InitParams
    {
        public bool AllowSwap { get; set; }

        public bool AllowAddLiquidity { get; set; }

        public bool AllowRemoveLiquidity { get; set; }

        public bool AllowIncreasePosition { get; set; }

        public bool AllowDecreasePosition { get; set; }

        public bool AllowCollateralWithdrawal { get; set; }

        public bool AllowLiquidatePosition { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(AllowSwap, offset);
            offset += 1;
            _data.WriteBool(AllowAddLiquidity, offset);
            offset += 1;
            _data.WriteBool(AllowRemoveLiquidity, offset);
            offset += 1;
            _data.WriteBool(AllowIncreasePosition, offset);
            offset += 1;
            _data.WriteBool(AllowDecreasePosition, offset);
            offset += 1;
            _data.WriteBool(AllowCollateralWithdrawal, offset);
            offset += 1;
            _data.WriteBool(AllowLiquidatePosition, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out InitParams result)
        {
            int offset = initialOffset;
            result = new InitParams();
            result.AllowSwap = _data.GetBool(offset);
            offset += 1;
            result.AllowAddLiquidity = _data.GetBool(offset);
            offset += 1;
            result.AllowRemoveLiquidity = _data.GetBool(offset);
            offset += 1;
            result.AllowIncreasePosition = _data.GetBool(offset);
            offset += 1;
            result.AllowDecreasePosition = _data.GetBool(offset);
            offset += 1;
            result.AllowCollateralWithdrawal = _data.GetBool(offset);
            offset += 1;
            result.AllowLiquidatePosition = _data.GetBool(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class LiquidateFullPosition2Params
    {
        public bool UsePriceUpdate { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(UsePriceUpdate, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out LiquidateFullPosition2Params result)
        {
            int offset = initialOffset;
            result = new LiquidateFullPosition2Params();
            result.UsePriceUpdate = _data.GetBool(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class RefreshAssetsUnderManagementParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out RefreshAssetsUnderManagementParams result)
        {
            int offset = initialOffset;
            result = new RefreshAssetsUnderManagementParams();
            return offset - initialOffset;
        }
    }

    public partial class RemoveLiquidityParams
    {
        public ulong LpAmountIn { get; set; }

        public ulong MinAmountOut { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(LpAmountIn, offset);
            offset += 8;
            _data.WriteU64(MinAmountOut, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out RemoveLiquidityParams result)
        {
            int offset = initialOffset;
            result = new RemoveLiquidityParams();
            result.LpAmountIn = _data.GetU64(offset);
            offset += 8;
            result.MinAmountOut = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SetCustodyConfigParams
    {
        public OracleParams Oracle { get; set; }

        public PricingParams Pricing { get; set; }

        public Permissions Permissions { get; set; }

        public ulong HourlyFundingBps { get; set; }

        public ulong TargetRatioBps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += Oracle.Serialize(_data, offset);
            offset += Pricing.Serialize(_data, offset);
            offset += Permissions.Serialize(_data, offset);
            _data.WriteU64(HourlyFundingBps, offset);
            offset += 8;
            _data.WriteU64(TargetRatioBps, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetCustodyConfigParams result)
        {
            int offset = initialOffset;
            result = new SetCustodyConfigParams();
            offset += OracleParams.Deserialize(_data, offset, out var resultOracle);
            result.Oracle = resultOracle;
            offset += PricingParams.Deserialize(_data, offset, out var resultPricing);
            result.Pricing = resultPricing;
            offset += Permissions.Deserialize(_data, offset, out var resultPermissions);
            result.Permissions = resultPermissions;
            result.HourlyFundingBps = _data.GetU64(offset);
            offset += 8;
            result.TargetRatioBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SetCustodyGlobalLimitParams
    {
        public ulong MaxGlobalLongSizes { get; set; }

        public ulong MaxGlobalShortSizes { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(MaxGlobalLongSizes, offset);
            offset += 8;
            _data.WriteU64(MaxGlobalShortSizes, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetCustodyGlobalLimitParams result)
        {
            int offset = initialOffset;
            result = new SetCustodyGlobalLimitParams();
            result.MaxGlobalLongSizes = _data.GetU64(offset);
            offset += 8;
            result.MaxGlobalShortSizes = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SetPerpetualsConfigParams
    {
        public Permissions Permissions { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += Permissions.Serialize(_data, offset);
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetPerpetualsConfigParams result)
        {
            int offset = initialOffset;
            result = new SetPerpetualsConfigParams();
            offset += Permissions.Deserialize(_data, offset, out var resultPermissions);
            result.Permissions = resultPermissions;
            return offset - initialOffset;
        }
    }

    public partial class SetPoolConfigParams
    {
        public Fees Fees { get; set; }

        public Limit Limit { get; set; }

        public long MaxRequestExecutionSec { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += Fees.Serialize(_data, offset);
            offset += Limit.Serialize(_data, offset);
            _data.WriteS64(MaxRequestExecutionSec, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetPoolConfigParams result)
        {
            int offset = initialOffset;
            result = new SetPoolConfigParams();
            offset += Fees.Deserialize(_data, offset, out var resultFees);
            result.Fees = resultFees;
            offset += Limit.Deserialize(_data, offset, out var resultLimit);
            result.Limit = resultLimit;
            result.MaxRequestExecutionSec = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SetTestOraclePriceParams
    {
        public ulong Price { get; set; }

        public int Expo { get; set; }

        public ulong Conf { get; set; }

        public long PublishTime { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(Price, offset);
            offset += 8;
            _data.WriteS32(Expo, offset);
            offset += 4;
            _data.WriteU64(Conf, offset);
            offset += 8;
            _data.WriteS64(PublishTime, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetTestOraclePriceParams result)
        {
            int offset = initialOffset;
            result = new SetTestOraclePriceParams();
            result.Price = _data.GetU64(offset);
            offset += 8;
            result.Expo = _data.GetS32(offset);
            offset += 4;
            result.Conf = _data.GetU64(offset);
            offset += 8;
            result.PublishTime = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SetTestTimeParams
    {
        public long Time { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteS64(Time, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetTestTimeParams result)
        {
            int offset = initialOffset;
            result = new SetTestTimeParams();
            result.Time = _data.GetS64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SwapExactOutParams
    {
        public ulong AmountOut { get; set; }

        public ulong MaxAmountIn { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(AmountOut, offset);
            offset += 8;
            _data.WriteU64(MaxAmountIn, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SwapExactOutParams result)
        {
            int offset = initialOffset;
            result = new SwapExactOutParams();
            result.AmountOut = _data.GetU64(offset);
            offset += 8;
            result.MaxAmountIn = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SwapParams
    {
        public ulong AmountIn { get; set; }

        public ulong MinAmountOut { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(AmountIn, offset);
            offset += 8;
            _data.WriteU64(MinAmountOut, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SwapParams result)
        {
            int offset = initialOffset;
            result = new SwapParams();
            result.AmountIn = _data.GetU64(offset);
            offset += 8;
            result.MinAmountOut = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class TestInitParams
    {
        public bool AllowSwap { get; set; }

        public bool AllowAddLiquidity { get; set; }

        public bool AllowRemoveLiquidity { get; set; }

        public bool AllowIncreasePosition { get; set; }

        public bool AllowDecreasePosition { get; set; }

        public bool AllowCollateralWithdrawal { get; set; }

        public bool AllowLiquidatePosition { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(AllowSwap, offset);
            offset += 1;
            _data.WriteBool(AllowAddLiquidity, offset);
            offset += 1;
            _data.WriteBool(AllowRemoveLiquidity, offset);
            offset += 1;
            _data.WriteBool(AllowIncreasePosition, offset);
            offset += 1;
            _data.WriteBool(AllowDecreasePosition, offset);
            offset += 1;
            _data.WriteBool(AllowCollateralWithdrawal, offset);
            offset += 1;
            _data.WriteBool(AllowLiquidatePosition, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out TestInitParams result)
        {
            int offset = initialOffset;
            result = new TestInitParams();
            result.AllowSwap = _data.GetBool(offset);
            offset += 1;
            result.AllowAddLiquidity = _data.GetBool(offset);
            offset += 1;
            result.AllowRemoveLiquidity = _data.GetBool(offset);
            offset += 1;
            result.AllowIncreasePosition = _data.GetBool(offset);
            offset += 1;
            result.AllowDecreasePosition = _data.GetBool(offset);
            offset += 1;
            result.AllowCollateralWithdrawal = _data.GetBool(offset);
            offset += 1;
            result.AllowLiquidatePosition = _data.GetBool(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class TransferAdminParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out TransferAdminParams result)
        {
            int offset = initialOffset;
            result = new TransferAdminParams();
            return offset - initialOffset;
        }
    }

    public partial class UpdateDecreasePositionRequestParams
    {
        public ulong SizeUsdDelta { get; set; }

        public ulong TriggerPrice { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU64(TriggerPrice, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateDecreasePositionRequestParams result)
        {
            int offset = initialOffset;
            result = new UpdateDecreasePositionRequestParams();
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.TriggerPrice = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class UpdateIncreasePositionRequestParams
    {
        public ulong SizeUsdDelta { get; set; }

        public ulong TriggerPrice { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(SizeUsdDelta, offset);
            offset += 8;
            _data.WriteU64(TriggerPrice, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateIncreasePositionRequestParams result)
        {
            int offset = initialOffset;
            result = new UpdateIncreasePositionRequestParams();
            result.SizeUsdDelta = _data.GetU64(offset);
            offset += 8;
            result.TriggerPrice = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class WithdrawFeesParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out WithdrawFeesParams result)
        {
            int offset = initialOffset;
            result = new WithdrawFeesParams();
            return offset - initialOffset;
        }
    }

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

    public partial class PricingParams
    {
        public ulong TradeSpreadLong { get; set; }

        public ulong TradeSpreadShort { get; set; }

        public ulong SwapSpread { get; set; }

        public ulong MaxLeverage { get; set; }

        public ulong MaxGlobalLongSizes { get; set; }

        public ulong MaxGlobalShortSizes { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(TradeSpreadLong, offset);
            offset += 8;
            _data.WriteU64(TradeSpreadShort, offset);
            offset += 8;
            _data.WriteU64(SwapSpread, offset);
            offset += 8;
            _data.WriteU64(MaxLeverage, offset);
            offset += 8;
            _data.WriteU64(MaxGlobalLongSizes, offset);
            offset += 8;
            _data.WriteU64(MaxGlobalShortSizes, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PricingParams result)
        {
            int offset = initialOffset;
            result = new PricingParams();
            result.TradeSpreadLong = _data.GetU64(offset);
            offset += 8;
            result.TradeSpreadShort = _data.GetU64(offset);
            offset += 8;
            result.SwapSpread = _data.GetU64(offset);
            offset += 8;
            result.MaxLeverage = _data.GetU64(offset);
            offset += 8;
            result.MaxGlobalLongSizes = _data.GetU64(offset);
            offset += 8;
            result.MaxGlobalShortSizes = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class FundingRateState
    {
        public BigInteger CumulativeInterestRate { get; set; }

        public long LastUpdate { get; set; }

        public ulong HourlyFundingBps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBigInt(CumulativeInterestRate, offset, 16, true);
            offset += 16;
            _data.WriteS64(LastUpdate, offset);
            offset += 8;
            _data.WriteU64(HourlyFundingBps, offset);
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
            result.HourlyFundingBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class OracleParams
    {
        public PublicKey OracleAccount { get; set; }

        public OracleType OracleType { get; set; }

        public ulong MaxPriceError { get; set; }

        public uint MaxPriceAgeSec { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WritePubKey(OracleAccount, offset);
            offset += 32;
            _data.WriteU8((byte)OracleType, offset);
            offset += 1;
            _data.WriteU64(MaxPriceError, offset);
            offset += 8;
            _data.WriteU32(MaxPriceAgeSec, offset);
            offset += 4;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out OracleParams result)
        {
            int offset = initialOffset;
            result = new OracleParams();
            result.OracleAccount = _data.GetPubKey(offset);
            offset += 32;
            result.OracleType = (OracleType)_data.GetU8(offset);
            offset += 1;
            result.MaxPriceError = _data.GetU64(offset);
            offset += 8;
            result.MaxPriceAgeSec = _data.GetU32(offset);
            offset += 4;
            return offset - initialOffset;
        }
    }

    public partial class Permissions
    {
        public bool AllowSwap { get; set; }

        public bool AllowAddLiquidity { get; set; }

        public bool AllowRemoveLiquidity { get; set; }

        public bool AllowIncreasePosition { get; set; }

        public bool AllowDecreasePosition { get; set; }

        public bool AllowCollateralWithdrawal { get; set; }

        public bool AllowLiquidatePosition { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBool(AllowSwap, offset);
            offset += 1;
            _data.WriteBool(AllowAddLiquidity, offset);
            offset += 1;
            _data.WriteBool(AllowRemoveLiquidity, offset);
            offset += 1;
            _data.WriteBool(AllowIncreasePosition, offset);
            offset += 1;
            _data.WriteBool(AllowDecreasePosition, offset);
            offset += 1;
            _data.WriteBool(AllowCollateralWithdrawal, offset);
            offset += 1;
            _data.WriteBool(AllowLiquidatePosition, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Permissions result)
        {
            int offset = initialOffset;
            result = new Permissions();
            result.AllowSwap = _data.GetBool(offset);
            offset += 1;
            result.AllowAddLiquidity = _data.GetBool(offset);
            offset += 1;
            result.AllowRemoveLiquidity = _data.GetBool(offset);
            offset += 1;
            result.AllowIncreasePosition = _data.GetBool(offset);
            offset += 1;
            result.AllowDecreasePosition = _data.GetBool(offset);
            offset += 1;
            result.AllowCollateralWithdrawal = _data.GetBool(offset);
            offset += 1;
            result.AllowLiquidatePosition = _data.GetBool(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class Fees
    {
        public ulong IncreasePositionBps { get; set; }

        public ulong DecreasePositionBps { get; set; }

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
            _data.WriteU64(IncreasePositionBps, offset);
            offset += 8;
            _data.WriteU64(DecreasePositionBps, offset);
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
            result.IncreasePositionBps = _data.GetU64(offset);
            offset += 8;
            result.DecreasePositionBps = _data.GetU64(offset);
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

    public partial class PoolApr
    {
        public long LastUpdated { get; set; }

        public ulong FeeAprBps { get; set; }

        public ulong RealizedFeeUsd { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteS64(LastUpdated, offset);
            offset += 8;
            _data.WriteU64(FeeAprBps, offset);
            offset += 8;
            _data.WriteU64(RealizedFeeUsd, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PoolApr result)
        {
            int offset = initialOffset;
            result = new PoolApr();
            result.LastUpdated = _data.GetS64(offset);
            offset += 8;
            result.FeeAprBps = _data.GetU64(offset);
            offset += 8;
            result.RealizedFeeUsd = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class Limit
    {
        public BigInteger MaxAumUsd { get; set; }

        public BigInteger TokenWeightageBufferBps { get; set; }

        public ulong MaxPositionUsd { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteBigInt(MaxAumUsd, offset, 16, true);
            offset += 16;
            _data.WriteBigInt(TokenWeightageBufferBps, offset, 16, true);
            offset += 16;
            _data.WriteU64(MaxPositionUsd, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Limit result)
        {
            int offset = initialOffset;
            result = new Limit();
            result.MaxAumUsd = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.TokenWeightageBufferBps = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.MaxPositionUsd = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public enum OracleType : byte
    {
        None,
        Test,
        Pyth
    }

    public enum PriceCalcMode : byte
    {
        Min,
        Max,
        Ignore
    }

    public enum RequestType : byte
    {
        Market,
        Trigger
    }

    public enum RequestChange : byte
    {
        None,
        Increase,
        Decrease
    }

    public enum Side : byte
    {
        None,
        Long,
        Short
    }
}
