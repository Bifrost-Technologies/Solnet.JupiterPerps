namespace Solnet.JupiterPerps.Types
{
    public partial class LiquidateBorrowPositionParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out LiquidateBorrowPositionParams result)
        {
            int offset = initialOffset;
            result = new LiquidateBorrowPositionParams();
            return offset - initialOffset;
        }
    }
}
