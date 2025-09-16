using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;

namespace Solnet.JupiterPerps
{
    public partial class TokenLedger
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 5572479096279660444UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 156, 247, 9, 188, 54, 108, 85, 77 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "TFkui5QKQvG";
        public PublicKey? TokenAccount { get; set; }

        public ulong Amount { get; set; }

        public static TokenLedger? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            TokenLedger result = new TokenLedger();
            result.TokenAccount = _data.GetPubKey(offset);
            offset += 32;
            result.Amount = _data.GetU64(offset);
            offset += 8;
            return result;
        }
    }
}
