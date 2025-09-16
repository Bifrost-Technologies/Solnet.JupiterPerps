namespace Solnet.JupiterPerps.Types
{
    public partial class IncreasePosition4Params
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out IncreasePosition4Params result)
        {
            int offset = initialOffset;
            result = new IncreasePosition4Params();
            return offset - initialOffset;
        }
    }
}
