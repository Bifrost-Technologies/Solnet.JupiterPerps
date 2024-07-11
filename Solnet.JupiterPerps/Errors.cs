using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.JupiterPerps.Errors
{
    public enum PerpetualsErrorKind : uint
    {
        MathOverflow = 6000U,
        UnsupportedOracle = 6001U,
        InvalidOracleAccount = 6002U,
        StaleOraclePrice = 6003U,
        InvalidOraclePrice = 6004U,
        InvalidEnvironment = 6005U,
        InvalidCollateralAccount = 6006U,
        InvalidCollateralAmount = 6007U,
        CollateralSlippage = 6008U,
        InvalidPositionState = 6009U,
        InvalidPerpetualsConfig = 6010U,
        InvalidPoolConfig = 6011U,
        InvalidInstruction = 6012U,
        InvalidCustodyConfig = 6013U,
        InvalidCustodyBalance = 6014U,
        InvalidArgument = 6015U,
        InvalidPositionRequest = 6016U,
        InvalidPositionRequestInputAta = 6017U,
        InvalidMint = 6018U,
        InsufficientTokenAmount = 6019U,
        InsufficientAmountReturned = 6020U,
        MaxPriceSlippage = 6021U,
        MaxLeverage = 6022U,
        CustodyAmountLimit = 6023U,
        PoolAmountLimit = 6024U,
        PersonalPoolAmountLimit = 6025U,
        UnsupportedToken = 6026U,
        InstructionNotAllowed = 6027U,
        JupiterProgramMismatch = 6028U,
        ProgramMismatch = 6029U,
        AddressMismatch = 6030U,
        KeeperATAMissing = 6031U,
        SwapAmountMismatch = 6032U,
        CPINotAllowed = 6033U,
        InvalidKeeper = 6034U,
        ExceedExecutionPeriod = 6035U,
        InvalidRequestType = 6036U,
        InvalidTriggerPrice = 6037U,
        TriggerPriceSlippage = 6038U,
        MissingTriggerPrice = 6039U,
        MissingPriceSlippage = 6040U,
        InvalidPriceCalcMode = 6041U,
        RequestUpdatedTooRecent = 6042U,
        ExceedTokenWeightage = 6043U,
        OraclePublishTimeTooEarly = 6044U,
        PullOraclePublishTimeTooEarly = 6045U,
        StalePullOraclePrice = 6046U,
        InvalidPullOraclePrice = 6047U,
        PullOracleNotVerified = 6048U,
        PriceDiffTooLarge = 6049U
    }
}
