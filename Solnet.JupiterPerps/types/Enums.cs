namespace Solnet.JupiterPerps.Types
{
    public enum OracleType : byte
    {
        None,
        Test,
        Pyth
    }

    public enum PriceCalcMode : byte
    {
        Min,
        Max,
        Ignore
    }

    public enum RequestType : byte
    {
        Market,
        Trigger
    }

    public enum RequestChange : byte
    {
        None,
        Increase,
        Decrease
    }

    public enum Side : byte
    {
        None,
        Long,
        Short
    }
}
