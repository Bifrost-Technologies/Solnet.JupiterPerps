using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Numerics;

namespace Solnet.JupiterPerps
{
    public partial class BorrowPosition
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 3995523140528934131UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 243, 140, 20, 139, 32, 243, 114, 55 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "hjiLtM2oecN";
        public PublicKey? Owner { get; set; }

        public PublicKey? Pool { get; set; }

        public PublicKey? Custody { get; set; }

        public long OpenTime { get; set; }

        public long UpdateTime { get; set; }

        public BigInteger BorrowSize { get; set; }

        public BigInteger CumulativeCompoundedInterestSnapshot { get; set; }

        public ulong LockedCollateral { get; set; }

        public byte Bump { get; set; }

        public long LastBorrowed { get; set; }

        public static BorrowPosition? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            BorrowPosition result = new BorrowPosition();
            result.Owner = _data.GetPubKey(offset);
            offset += 32;
            result.Pool = _data.GetPubKey(offset);
            offset += 32;
            result.Custody = _data.GetPubKey(offset);
            offset += 32;
            result.OpenTime = _data.GetS64(offset);
            offset += 8;
            result.UpdateTime = _data.GetS64(offset);
            offset += 8;
            result.BorrowSize = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.CumulativeCompoundedInterestSnapshot = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.LockedCollateral = _data.GetU64(offset);
            offset += 8;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            result.LastBorrowed = _data.GetS64(offset);
            offset += 8;
            return result;
        }
    }
}
