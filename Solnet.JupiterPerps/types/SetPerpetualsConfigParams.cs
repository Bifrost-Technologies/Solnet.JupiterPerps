using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class SetPerpetualsConfigParams
    {
        public Permissions? Permissions { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += Permissions!.Serialize(_data, offset);
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetPerpetualsConfigParams result)
        {
            int offset = initialOffset;
            result = new SetPerpetualsConfigParams();
            offset += Permissions.Deserialize(_data, offset, out var resultPermissions);
            result.Permissions = resultPermissions;
            return offset - initialOffset;
        }
    }
}
