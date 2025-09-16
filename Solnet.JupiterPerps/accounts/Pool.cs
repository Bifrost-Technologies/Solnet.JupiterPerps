using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Numerics;

namespace Solnet.JupiterPerps
{
    public partial class Pool
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 13577703138238765809UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 241, 154, 109, 4, 17, 177, 109, 188 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "hQrXeCntzbV";
        public string? Name { get; set; }

        public PublicKey[]? Custodies { get; set; }

        public BigInteger AumUsd { get; set; }

        public Limit? Limit { get; set; }

        public Fees? Fees { get; set; }

        public PoolApr? PoolApr { get; set; }

        public long MaxRequestExecutionSec { get; set; }

        public byte Bump { get; set; }

        public byte LpTokenBump { get; set; }

        public long InceptionTime { get; set; }

        public Secp256k1Pubkey? ParameterUpdateOracle { get; set; }

        public long AumUsdUpdatedAt { get; set; }

        public static Pool? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            Pool result = new Pool();
            offset += _data.GetBorshString(offset, out var resultName);
            result.Name = resultName;
            int resultCustodiesLength = (int)_data.GetU32(offset);
            offset += 4;
            result.Custodies = new PublicKey[resultCustodiesLength];
            for (uint resultCustodiesIdx = 0; resultCustodiesIdx < resultCustodiesLength; resultCustodiesIdx++)
            {
                result.Custodies[resultCustodiesIdx] = _data.GetPubKey(offset);
                offset += 32;
            }

            result.AumUsd = _data.GetBigInt(offset, 16, false);
            offset += 16;
            offset += Limit.Deserialize(_data, offset, out var resultLimit);
            result.Limit = resultLimit;
            offset += Fees.Deserialize(_data, offset, out var resultFees);
            result.Fees = resultFees;
            offset += PoolApr.Deserialize(_data, offset, out var resultPoolApr);
            result.PoolApr = resultPoolApr;
            result.MaxRequestExecutionSec = _data.GetS64(offset);
            offset += 8;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            result.LpTokenBump = _data.GetU8(offset);
            offset += 1;
            result.InceptionTime = _data.GetS64(offset);
            offset += 8;
            offset += Secp256k1Pubkey.Deserialize(_data, offset, out var resultParameterUpdateOracle);
            result.ParameterUpdateOracle = resultParameterUpdateOracle;
            result.AumUsdUpdatedAt = _data.GetS64(offset);
            offset += 8;
            return result;
        }
    }
}
