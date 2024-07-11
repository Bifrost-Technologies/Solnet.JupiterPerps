using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Solnet.Rpc.Models;
using System.Threading.Tasks;
using Solnet.JupiterPerps.Models;

namespace Solnet.JupiterPerps
{
    public static class PerpetualsProgram
    {
        public static PublicKey programId = new PublicKey("PERPHjGBqRHArX4DySjwM6UJHiR3sWAatqfdBS2qQJu");
        public static PublicKey systemProgram = new PublicKey("11111111111111111111111111111111");
        public static PublicKey tokenProgram = new PublicKey("TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA");
        public static PublicKey associatedtokenProgram = new PublicKey("ATokenGPvbdGVxr1b2hvZbsiqW5xWH25efTNsLJA8knL");
        public static TransactionInstruction Swap(SwapAccounts accounts, SwapParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.ReceivingCustody, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyOracleAccount, false), AccountMeta.Writable(accounts.ReceivingCustodyTokenAccount, false), AccountMeta.Writable(accounts.DispensingCustody, false), AccountMeta.ReadOnly(accounts.DispensingCustodyOracleAccount, false), AccountMeta.Writable(accounts.DispensingCustodyTokenAccount, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(14449647541112719096UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction SwapExactOut(SwapExactOutAccounts accounts, SwapExactOutParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.ReceivingCustody, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyOracleAccount, false), AccountMeta.Writable(accounts.ReceivingCustodyTokenAccount, false), AccountMeta.Writable(accounts.DispensingCustody, false), AccountMeta.ReadOnly(accounts.DispensingCustodyOracleAccount, false), AccountMeta.Writable(accounts.DispensingCustodyTokenAccount, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(13279935688908032506UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction AddLiquidity(AddLiquidityAccounts accounts, AddLiquidityParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.Writable(accounts.LpTokenAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.Writable(accounts.LpTokenMint, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(5202984195946290613UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction RemoveLiquidity(RemoveLiquidityAccounts accounts, RemoveLiquidityParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.Writable(accounts.LpTokenAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.Writable(accounts.LpTokenMint, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(7832267830670218576UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction CreateIncreasePositionRequest(CreateIncreasePositionRequestAccounts accounts, CreateIncreasePositionRequestParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.InputMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(associatedtokenProgram, false), AccountMeta.ReadOnly(systemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(9936148977559379976UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction CreateIncreasePositionMarketRequest(CreateIncreasePositionMarketRequestAccounts accounts, CreateIncreasePositionMarketRequestParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.InputMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(associatedtokenProgram, false), AccountMeta.ReadOnly(systemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(4079323830366459320UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction UpdateIncreasePositionRequest(UpdateIncreasePositionRequestAccounts accounts, UpdateIncreasePositionRequestParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(11342605204174630500UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction CreateDecreasePositionRequest(CreateDecreasePositionRequestAccounts accounts, CreateDecreasePositionRequestParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.DesiredMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(associatedtokenProgram, false), AccountMeta.ReadOnly(systemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(4974173817064854930UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction CreateDecreasePositionMarketRequest(CreateDecreasePositionMarketRequestAccounts accounts, CreateDecreasePositionMarketRequestParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.DesiredMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(associatedtokenProgram, false), AccountMeta.ReadOnly(systemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(5692941086008526410UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction UpdateDecreasePositionRequest(UpdateDecreasePositionRequestAccounts accounts, UpdateDecreasePositionRequestParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(10570252059842980933UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction ClosePositionRequest(ClosePositionRequestAccounts accounts, ClosePositionRequestParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.Writable(accounts.Owner, false), AccountMeta.Writable(accounts.OwnerAta, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(7957066542717954344UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction LiquidateFullPosition2(LiquidateFullPosition2Accounts accounts, LiquidateFullPosition2Params parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Signer, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyOracleAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.CustodyPriceUpdate, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPriceUpdate, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(programId, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(17956109010293465321UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetAddLiquidityAmountAndFee(GetAddLiquidityAmountAndFeeAccounts accounts, GetAddLiquidityAmountAndFeeParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(10038226605538121388UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetRemoveLiquidityAmountAndFee(GetRemoveLiquidityAmountAndFeeAccounts accounts, GetRemoveLiquidityAmountAndFeeParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(559595405301113538UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetIncreasePosition(GetIncreasePositionAccounts accounts, GetIncreasePositionParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CustodyPriceUpdate, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPriceUpdate, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(7348527647711855461UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetDecreasePosition(GetDecreasePositionAccounts accounts, GetDecreasePositionParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CustodyPriceUpdate, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPriceUpdate, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(18028028501282660202UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetPnl(GetPnlAccounts accounts, GetPnlAndFeeParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CustodyPriceUpdate, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(11547476576895751274UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetLiquidationState(GetLiquidationStateAccounts accounts, GetLiquidationStateParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(3611140721278942847UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetOraclePrice(GetOraclePriceAccounts accounts)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.CustodyPriceUpdate, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(10153033549691753672UL, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetSwapAmountAndFees(GetSwapAmountAndFeesAccounts accounts, GetSwapAmountAndFeesParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.ReceivingCustody, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.DispensingCustody, false), AccountMeta.ReadOnly(accounts.DispensingCustodyOracleAccount, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(2334080818825689591UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction GetExactOutSwapAmountAndFees(GetExactOutSwapAmountAndFeesAccounts accounts, GetExactOutSwapAmountAndFeesParams parameters)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.ReceivingCustody, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyOracleAccount, false), AccountMeta.ReadOnly(accounts.DispensingCustody, false), AccountMeta.ReadOnly(accounts.DispensingCustodyOracleAccount, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(4047585526865862852UL, offset);
            offset += 8;
            offset += parameters.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

    
    }
}
