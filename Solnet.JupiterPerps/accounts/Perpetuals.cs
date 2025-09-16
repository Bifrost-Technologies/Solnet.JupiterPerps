using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;

namespace Solnet.JupiterPerps
{
    public partial class Perpetuals
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 14153778338759616284UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 28, 167, 98, 191, 104, 82, 108, 196 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "5nyjp1aZDB1";
        public Permissions? Permissions { get; set; }

        public PublicKey[]? Pools { get; set; }

        public PublicKey? Admin { get; set; }

        public byte TransferAuthorityBump { get; set; }

        public byte PerpetualsBump { get; set; }

        public long InceptionTime { get; set; }

        public static Perpetuals? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            Perpetuals result = new Perpetuals();
            offset += Permissions.Deserialize(_data, offset, out var resultPermissions);
            result.Permissions = resultPermissions;
            int resultPoolsLength = (int)_data.GetU32(offset);
            offset += 4;
            result.Pools = new PublicKey[resultPoolsLength];
            for (uint resultPoolsIdx = 0; resultPoolsIdx < resultPoolsLength; resultPoolsIdx++)
            {
                result.Pools[resultPoolsIdx] = _data.GetPubKey(offset);
                offset += 32;
            }

            result.Admin = _data.GetPubKey(offset);
            offset += 32;
            result.TransferAuthorityBump = _data.GetU8(offset);
            offset += 1;
            result.PerpetualsBump = _data.GetU8(offset);
            offset += 1;
            result.InceptionTime = _data.GetS64(offset);
            offset += 8;
            return result;
        }
    }
}
