namespace Solnet.JupiterPerps.Types
{
    public partial class WithdrawFees2Params
    {
        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out WithdrawFees2Params result)
        {
            int offset = initialOffset;
            result = new WithdrawFees2Params();
            return offset - initialOffset;
        }
    }
}
