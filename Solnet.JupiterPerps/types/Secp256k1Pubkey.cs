using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class Secp256k1Pubkey
    {
        public byte Prefix { get; set; }

        public byte[]? Key { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU8(Prefix, offset);
            offset += 1;
            _data.WriteSpan(Key, offset);
            offset += Key!.Length;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Secp256k1Pubkey result)
        {
            int offset = initialOffset;
            result = new Secp256k1Pubkey();
            result.Prefix = _data.GetU8(offset);
            offset += 1;
            result.Key = _data.GetBytes(offset, 32);
            offset += 32;
            return offset - initialOffset;
        }
    }
}
