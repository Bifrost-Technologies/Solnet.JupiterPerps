using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.JupiterPerps
{
    public static class PDALookup
    {
      
        public static PublicKey FindCustodyPDA(PublicKey tokenAddress)
        {
            PublicKey.TryFindProgramAddress(new List<byte[]>()
            {
                Encoding.UTF8.GetBytes("custody"),
                tokenAddress
            },
            PerpetualsProgram.programId,
            out PublicKey custodyAddress,
            out _);

            return custodyAddress;
        }
        public static PublicKey FindPoolPDA(PublicKey Address)
        {
            PublicKey.TryFindProgramAddress(new List<byte[]>()
            {
                Encoding.UTF8.GetBytes("pool"),
                Address
            },
            PerpetualsProgram.programId,
            out PublicKey poolAddress,
            out _);

            return poolAddress;
        }
        public static PublicKey FindPerpetualsPDA(PublicKey Address)
        {
            PublicKey.TryFindProgramAddress(new List<byte[]>()
            {
                Encoding.UTF8.GetBytes("perpetuals"),
               Address
            },
            PerpetualsProgram.programId,
            out PublicKey perpAddress,
            out _);

            return perpAddress;
        }
    }
}
