namespace Solnet.JupiterPerps.Types
{
    public partial class DecreasePosition4Params
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out DecreasePosition4Params result)
        {
            int offset = initialOffset;
            result = new DecreasePosition4Params();
            return offset - initialOffset;
        }
    }
}
