namespace Solnet.JupiterPerps.Types
{
    public partial class ClosePositionRequestParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out ClosePositionRequestParams result)
        {
            int offset = initialOffset;
            result = new ClosePositionRequestParams();
            return offset - initialOffset;
        }
    }
}
