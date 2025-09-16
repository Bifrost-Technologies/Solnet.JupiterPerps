namespace Solnet.JupiterPerps.Types
{
    public partial class LiquidateFullPosition4Params
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out LiquidateFullPosition4Params result)
        {
            int offset = initialOffset;
            result = new LiquidateFullPosition4Params();
            return offset - initialOffset;
        }
    }
}
