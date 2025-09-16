namespace Solnet.JupiterPerps.Types
{
    public partial class CloseBorrowPositionParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CloseBorrowPositionParams result)
        {
            int offset = initialOffset;
            result = new CloseBorrowPositionParams();
            return offset - initialOffset;
        }
    }
}
