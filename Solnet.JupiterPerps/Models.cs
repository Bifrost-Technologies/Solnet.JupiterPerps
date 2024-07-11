using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.JupiterPerps.Models
{

    public class SwapAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey FundingAccount { get; set; }

        public PublicKey ReceivingAccount { get; set; }

        public PublicKey TransferAuthority { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey ReceivingCustody { get; set; }

        public PublicKey ReceivingCustodyOracleAccount { get; set; }

        public PublicKey ReceivingCustodyTokenAccount { get; set; }

        public PublicKey DispensingCustody { get; set; }

        public PublicKey DispensingCustodyOracleAccount { get; set; }

        public PublicKey DispensingCustodyTokenAccount { get; set; }

        public PublicKey TokenProgram { get; set; }

        public PublicKey EventAuthority { get; set; }

        public PublicKey Program { get; set; }
    }

    public class SwapExactOutAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey FundingAccount { get; set; }

        public PublicKey ReceivingAccount { get; set; }

        public PublicKey TransferAuthority { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey ReceivingCustody { get; set; }

        public PublicKey ReceivingCustodyOracleAccount { get; set; }

        public PublicKey ReceivingCustodyTokenAccount { get; set; }

        public PublicKey DispensingCustody { get; set; }

        public PublicKey DispensingCustodyOracleAccount { get; set; }

        public PublicKey DispensingCustodyTokenAccount { get; set; }

        public PublicKey TokenProgram { get; set; }

        public PublicKey EventAuthority { get; set; }

        public PublicKey Program { get; set; }
    }

    public class AddLiquidityAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey FundingAccount { get; set; }

        public PublicKey LpTokenAccount { get; set; }

        public PublicKey TransferAuthority { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CustodyTokenAccount { get; set; }

        public PublicKey LpTokenMint { get; set; }

        public PublicKey TokenProgram { get; set; }

        public PublicKey EventAuthority { get; set; }

        public PublicKey Program { get; set; }
    }

    public class RemoveLiquidityAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey ReceivingAccount { get; set; }

        public PublicKey LpTokenAccount { get; set; }

        public PublicKey TransferAuthority { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CustodyTokenAccount { get; set; }

        public PublicKey LpTokenMint { get; set; }

        public PublicKey EventAuthority { get; set; }
    }

    public class CreateIncreasePositionRequestAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey FundingAccount { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey InputMint { get; set; }

        public PublicKey Referral { get; set; }

        public PublicKey EventAuthority { get; set; }

    }

    public class CreateIncreasePositionMarketRequestAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey FundingAccount { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey InputMint { get; set; }

        public PublicKey Referral { get; set; }

        public PublicKey EventAuthority { get; set; }

      
    }

    public class UpdateIncreasePositionRequestAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }
    }

    public class CreateDecreasePositionRequestAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey ReceivingAccount { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey DesiredMint { get; set; }

        public PublicKey Referral { get; set; }

        public PublicKey EventAuthority { get; set; }

 
    }

    public class CreateDecreasePositionMarketRequestAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey ReceivingAccount { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey DesiredMint { get; set; }

        public PublicKey Referral { get; set; }

        public PublicKey EventAuthority { get; set; }

    }

    public class UpdateDecreasePositionRequestAccounts
    {
        public PublicKey Owner { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }
    }

    public class ClosePositionRequestAccounts
    {
        public PublicKey Keeper { get; set; }

        public PublicKey Owner { get; set; }

        public PublicKey OwnerAta { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey EventAuthority { get; set; }

    }

    public class IncreasePosition2Accounts
    {
        public PublicKey Keeper { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey CollateralCustodyOracleAccount { get; set; }

        public PublicKey CollateralCustodyTokenAccount { get; set; }

        public PublicKey CustodyPriceUpdate { get; set; }

        public PublicKey CollateralCustodyPriceUpdate { get; set; }

        public PublicKey EventAuthority { get; set; }

    }

    public class IncreasePositionPreSwapAccounts
    {
        public PublicKey Keeper { get; set; }

        public PublicKey KeeperAta { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey CollateralCustodyTokenAccount { get; set; }

        public PublicKey Instruction { get; set; }

        public PublicKey EventAuthority { get; set; }

    }

    public class DecreasePosition2Accounts
    {
        public PublicKey Keeper { get; set; }

        public PublicKey KeeperAta { get; set; }

        public PublicKey Owner { get; set; }

        public PublicKey TransferAuthority { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey CollateralCustodyOracleAccount { get; set; }

        public PublicKey CollateralCustodyTokenAccount { get; set; }

        public PublicKey Instruction { get; set; }

        public PublicKey CustodyPriceUpdate { get; set; }

        public PublicKey CollateralCustodyPriceUpdate { get; set; }

        public PublicKey EventAuthority { get; set; }

    }

    public class DecreasePositionPostSwapAccounts
    {
        public PublicKey Keeper { get; set; }

        public PublicKey PositionRequest { get; set; }

        public PublicKey PositionRequestAta { get; set; }

        public PublicKey EventAuthority { get; set; }

    }

    public class LiquidateFullPosition2Accounts
    {
        public PublicKey Signer { get; set; }

        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey CollateralCustodyOracleAccount { get; set; }

        public PublicKey CollateralCustodyTokenAccount { get; set; }

        public PublicKey CustodyPriceUpdate { get; set; }

        public PublicKey CollateralCustodyPriceUpdate { get; set; }

        public PublicKey EventAuthority { get; set; }
    }

    
    public class GetAddLiquidityAmountAndFeeAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey LpTokenMint { get; set; }
    }

    public class GetRemoveLiquidityAmountAndFeeAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey LpTokenMint { get; set; }
    }

    public class GetIncreasePositionAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey CollateralCustodyOracleAccount { get; set; }

        public PublicKey CustodyPriceUpdate { get; set; }

        public PublicKey CollateralCustodyPriceUpdate { get; set; }
    }

    public class GetDecreasePositionAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey CollateralCustodyOracleAccount { get; set; }

        public PublicKey CustodyPriceUpdate { get; set; }

        public PublicKey CollateralCustodyPriceUpdate { get; set; }
    }

    public class GetPnlAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }

        public PublicKey CustodyPriceUpdate { get; set; }
    }

    public class GetLiquidationStateAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Position { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CollateralCustody { get; set; }
    }

    public class GetOraclePriceAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey Custody { get; set; }

        public PublicKey CustodyOracleAccount { get; set; }

        public PublicKey CustodyPriceUpdate { get; set; }
    }

    public class GetSwapAmountAndFeesAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey ReceivingCustody { get; set; }

        public PublicKey ReceivingCustodyOracleAccount { get; set; }

        public PublicKey DispensingCustody { get; set; }

        public PublicKey DispensingCustodyOracleAccount { get; set; }
    }

    public class GetExactOutSwapAmountAndFeesAccounts
    {
        public PublicKey Perpetuals { get; set; }

        public PublicKey Pool { get; set; }

        public PublicKey ReceivingCustody { get; set; }

        public PublicKey ReceivingCustodyOracleAccount { get; set; }

        public PublicKey DispensingCustody { get; set; }

        public PublicKey DispensingCustodyOracleAccount { get; set; }
    }

 

}
