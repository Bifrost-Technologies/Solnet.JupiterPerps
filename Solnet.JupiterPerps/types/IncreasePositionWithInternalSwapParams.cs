namespace Solnet.JupiterPerps.Types
{
    public partial class IncreasePositionWithInternalSwapParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out IncreasePositionWithInternalSwapParams result)
        {
            int offset = initialOffset;
            result = new IncreasePositionWithInternalSwapParams();
            return offset - initialOffset;
        }
    }
}
