namespace Solnet.JupiterPerps.Types
{
    public partial class TransferAdminParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out TransferAdminParams result)
        {
            int offset = initialOffset;
            result = new TransferAdminParams();
            return offset - initialOffset;
        }
    }
}
