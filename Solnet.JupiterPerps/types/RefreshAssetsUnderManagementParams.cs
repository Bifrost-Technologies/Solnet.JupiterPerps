namespace Solnet.JupiterPerps.Types
{
    public partial class RefreshAssetsUnderManagementParams
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out RefreshAssetsUnderManagementParams result)
        {
            int offset = initialOffset;
            result = new RefreshAssetsUnderManagementParams();
            return offset - initialOffset;
        }
    }
}
