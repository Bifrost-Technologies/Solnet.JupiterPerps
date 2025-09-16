using Solnet.Programs.Utilities;
using Solnet.Wallet;

namespace Solnet.JupiterPerps.Types
{
    public partial class OracleParams
    {
        public PublicKey? OracleAccount { get; set; }

        public OracleType OracleType { get; set; }

        public ulong Buffer { get; set; }

        public uint MaxPriceAgeSec { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WritePubKey(OracleAccount, offset);
            offset += 32;
            _data.WriteU8((byte)OracleType, offset);
            offset += 1;
            _data.WriteU64(Buffer, offset);
            offset += 8;
            _data.WriteU32(MaxPriceAgeSec, offset);
            offset += 4;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out OracleParams result)
        {
            int offset = initialOffset;
            result = new OracleParams();
            result.OracleAccount = _data.GetPubKey(offset);
            offset += 32;
            result.OracleType = (OracleType)_data.GetU8(offset);
            offset += 1;
            result.Buffer = _data.GetU64(offset);
            offset += 8;
            result.MaxPriceAgeSec = _data.GetU32(offset);
            offset += 4;
            return offset - initialOffset;
        }
    }
}
