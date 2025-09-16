using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Numerics;

namespace Solnet.JupiterPerps
{
    public partial class Position
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 15057574775701355690UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 170, 188, 143, 228, 122, 64, 247, 208 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "VZMoMoKgZQb";
        public PublicKey? Owner { get; set; }

        public PublicKey? Pool { get; set; }

        public PublicKey? Custody { get; set; }

        public PublicKey? CollateralCustody { get; set; }

        public long OpenTime { get; set; }

        public long UpdateTime { get; set; }

        public Side Side { get; set; }

        public ulong Price { get; set; }

        public ulong SizeUsd { get; set; }

        public ulong CollateralUsd { get; set; }

        public long RealisedPnlUsd { get; set; }

        public BigInteger CumulativeInterestSnapshot { get; set; }

        public ulong LockedAmount { get; set; }

        public byte Bump { get; set; }

        public static Position? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            Position result = new Position();
            result.Owner = _data.GetPubKey(offset);
            offset += 32;
            result.Pool = _data.GetPubKey(offset);
            offset += 32;
            result.Custody = _data.GetPubKey(offset);
            offset += 32;
            result.CollateralCustody = _data.GetPubKey(offset);
            offset += 32;
            result.OpenTime = _data.GetS64(offset);
            offset += 8;
            result.UpdateTime = _data.GetS64(offset);
            offset += 8;
            result.Side = (Side)_data.GetU8(offset);
            offset += 1;
            result.Price = _data.GetU64(offset);
            offset += 8;
            result.SizeUsd = _data.GetU64(offset);
            offset += 8;
            result.CollateralUsd = _data.GetU64(offset);
            offset += 8;
            result.RealisedPnlUsd = _data.GetS64(offset);
            offset += 8;
            result.CumulativeInterestSnapshot = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.LockedAmount = _data.GetU64(offset);
            offset += 8;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            return result;
        }
    }
}
