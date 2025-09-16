using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
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
}
