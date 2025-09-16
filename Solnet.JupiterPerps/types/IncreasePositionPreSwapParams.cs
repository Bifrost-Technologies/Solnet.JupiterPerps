namespace Solnet.JupiterPerps.Types
{
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
}
