namespace Solnet.JupiterPerps.Types
{
    public partial class DecreasePositionWithTpslAndInternalSwapParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out DecreasePositionWithTpslAndInternalSwapParams result)
        {
            int offset = initialOffset;
            result = new DecreasePositionWithTpslAndInternalSwapParams();
            return offset - initialOffset;
        }
    }
}
