using Solnet.Programs.Utilities;

namespace Solnet.JupiterPerps.Types
{
    public partial class CreateTokenMetadataParams
    {
        public string? Name { get; set; }

        public string? Symbol { get; set; }

        public string? Uri { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += _data.WriteBorshString(Name, offset);
            offset += _data.WriteBorshString(Symbol, offset);
            offset += _data.WriteBorshString(Uri, offset);
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out CreateTokenMetadataParams result)
        {
            int offset = initialOffset;
            result = new CreateTokenMetadataParams();
            offset += _data.GetBorshString(offset, out var resultName);
            result.Name = resultName;
            offset += _data.GetBorshString(offset, out var resultSymbol);
            result.Symbol = resultSymbol;
            offset += _data.GetBorshString(offset, out var resultUri);
            result.Uri = resultUri;
            return offset - initialOffset;
        }
    }
}
