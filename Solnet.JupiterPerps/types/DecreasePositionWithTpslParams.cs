namespace Solnet.JupiterPerps.Types
{
    public partial class DecreasePositionWithTpslParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out DecreasePositionWithTpslParams result)
        {
            int offset = initialOffset;
            result = new DecreasePositionWithTpslParams();
            return offset - initialOffset;
        }
    }
}
