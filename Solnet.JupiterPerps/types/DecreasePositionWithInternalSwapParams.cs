namespace Solnet.JupiterPerps.Types
{
    public partial class DecreasePositionWithInternalSwapParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out DecreasePositionWithInternalSwapParams result)
        {
            int offset = initialOffset;
            result = new DecreasePositionWithInternalSwapParams();
            return offset - initialOffset;
        }
    }
}
