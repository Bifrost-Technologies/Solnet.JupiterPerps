using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class SetMaxGlobalSizesParams
    {
        public ulong MaxGlobalLongSize { get; set; }

        public ulong MaxGlobalShortSize { get; set; }

        public byte RecoveryId { get; set; }

        public byte[]? Signature { get; set; }

        public byte[]? ReferenceId { get; set; }

        public ulong Timestamp { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(MaxGlobalLongSize, offset);
            offset += 8;
            _data.WriteU64(MaxGlobalShortSize, offset);
            offset += 8;
            _data.WriteU8(RecoveryId, offset);
            offset += 1;
            _data.WriteSpan(Signature, offset);
            offset += Signature!.Length;
            _data.WriteSpan(ReferenceId, offset);
            offset += ReferenceId!.Length;
            _data.WriteU64(Timestamp, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetMaxGlobalSizesParams result)
        {
            int offset = initialOffset;
            result = new SetMaxGlobalSizesParams();
            result.MaxGlobalLongSize = _data.GetU64(offset);
            offset += 8;
            result.MaxGlobalShortSize = _data.GetU64(offset);
            offset += 8;
            result.RecoveryId = _data.GetU8(offset);
            offset += 1;
            result.Signature = _data.GetBytes(offset, 64);
            offset += 64;
            result.ReferenceId = _data.GetBytes(offset, 16);
            offset += 16;
            result.Timestamp = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
