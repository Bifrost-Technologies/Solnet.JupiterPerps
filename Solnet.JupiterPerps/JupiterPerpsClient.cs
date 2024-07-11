using Solnet.JupiterPerps.Types;
using Solnet.JupiterPerps.Models;
using Solnet.Programs.Models;
using Solnet.Rpc.Types;
using Solnet.Rpc.Models;
using Solnet.Rpc;
using Solnet.Wallet;
using Solnet.Programs;
using Solnet.Rpc.Builders;

namespace Solnet.JupiterPerps
{
    public partial class PerpetualsClient 
    {
        public IRpcClient RpcClient {  get; set; }
        public PerpetualsClient(IRpcClient rpcClient)
        {
            this.RpcClient = rpcClient;
        }

        public async Task<ProgramAccountsResultWrapper<List<Custody>>> GetCustodysAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Custody.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Custody>>(res);
            List<Custody> resultingAccounts = new List<Custody>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Custody.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<Custody>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<TestOracle>>> GetTestOraclesAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = TestOracle.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<TestOracle>>(res);
            List<TestOracle> resultingAccounts = new List<TestOracle>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => TestOracle.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<TestOracle>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<Perpetuals>>> GetPerpetualssAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Perpetuals.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Perpetuals>>(res);
            List<Perpetuals> resultingAccounts = new List<Perpetuals>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Perpetuals.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<Perpetuals>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<Pool>>> GetPoolsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Pool.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Pool>>(res);
            List<Pool> resultingAccounts = new List<Pool>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Pool.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<Pool>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<PositionRequest>>> GetPositionRequestsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = PositionRequest.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<PositionRequest>>(res);
            List<PositionRequest> resultingAccounts = new List<PositionRequest>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => PositionRequest.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<PositionRequest>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<Position>>> GetPositionsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Position.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Position>>(res);
            List<Position> resultingAccounts = new List<Position>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Position.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<Position>>(res, resultingAccounts);
        }

        public async Task<AccountResultWrapper<Custody>> GetCustodyAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Custody>(res);
            var resultingAccount = Custody.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Custody>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<TestOracle>> GetTestOracleAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<TestOracle>(res);
            var resultingAccount = TestOracle.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<TestOracle>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<Perpetuals>> GetPerpetualsAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Perpetuals>(res);
            var resultingAccount = Perpetuals.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Perpetuals>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<Pool>> GetPoolAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Pool>(res);
            var resultingAccount = Pool.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Pool>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<PositionRequest>> GetPositionRequestAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<PositionRequest>(res);
            var resultingAccount = PositionRequest.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<PositionRequest>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<Position>> GetPositionAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Position>(res);
            var resultingAccount = Position.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Position>(res, resultingAccount);
        }

      
      
        public async Task<TransactionInstruction> SendSwapAsync(SwapAccounts accounts, SwapParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.Swap(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendSwapExactOutAsync(SwapExactOutAccounts accounts, SwapExactOutParams parameters, PublicKey feePayer)
        {
            TransactionInstruction instr = PerpetualsProgram.SwapExactOut(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendAddLiquidityAsync(AddLiquidityAccounts accounts, AddLiquidityParams parameters, PublicKey feePayer)
        {
            TransactionInstruction instr = PerpetualsProgram.AddLiquidity(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendRemoveLiquidityAsync(RemoveLiquidityAccounts accounts, RemoveLiquidityParams parameters, PublicKey feePayer)
        {
            TransactionInstruction instr = PerpetualsProgram.RemoveLiquidity(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendCreateIncreasePositionRequestAsync(CreateIncreasePositionRequestAccounts accounts, CreateIncreasePositionRequestParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.CreateIncreasePositionRequest(accounts, parameters);
           return instr;
        }

        public async Task<string> SendCreateIncreasePositionAsync(Account tradingAccount, ulong collateral_sol_amount, CreateIncreasePositionMarketRequestAccounts instruction_accounts, CreateIncreasePositionMarketRequestParams parameters)
        {
            TransactionInstruction test = PerpetualsProgram.CreateIncreasePositionMarketRequest(instruction_accounts, parameters);
            TransactionInstruction transfer = SystemProgram.Transfer(tradingAccount.PublicKey, AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(tradingAccount.PublicKey, new PublicKey("So11111111111111111111111111111111111111112")), collateral_sol_amount);
            TransactionInstruction syncSol = TokenProgram.SyncNative(AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(tradingAccount.PublicKey, new PublicKey("So11111111111111111111111111111111111111112")));
            LatestBlockHash latestBlockHash = RpcClient.GetLatestBlockHash().Result.Value;
            TransactionBuilder TB = new TransactionBuilder();

            TB.AddInstruction(AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(tradingAccount.PublicKey, tradingAccount.PublicKey, new PublicKey("So11111111111111111111111111111111111111112")));
            TB.AddInstruction(transfer);
            TB.AddInstruction(syncSol);
            TB.AddInstruction(test);
            TB.SetRecentBlockHash(latestBlockHash.Blockhash);
            TB.SetFeePayer(tradingAccount.PublicKey);
            byte[] signedTX = TB.Build(tradingAccount);

            var tx = await RpcClient.SendTransactionAsync(signedTX);
            return tx.RawRpcResponse;
        }

        public async Task<TransactionInstruction> SendUpdateIncreasePositionAsync(UpdateIncreasePositionRequestAccounts accounts, UpdateIncreasePositionRequestParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.UpdateIncreasePositionRequest(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendCreateDecreasePositionAsync(CreateDecreasePositionRequestAccounts accounts, CreateDecreasePositionRequestParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.CreateDecreasePositionRequest(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendCreateDecreasePositionMarketAsync(CreateDecreasePositionMarketRequestAccounts accounts, CreateDecreasePositionMarketRequestParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.CreateDecreasePositionMarketRequest(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendUpdateDecreasePositionAsync(UpdateDecreasePositionRequestAccounts accounts, UpdateDecreasePositionRequestParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.UpdateDecreasePositionRequest(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendClosePositionAsync(ClosePositionRequestAccounts accounts, ClosePositionRequestParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.ClosePositionRequest(accounts, parameters);
           return instr;
        }

     
        public async Task<TransactionInstruction> SendLiquidateFullPosition2Async(LiquidateFullPosition2Accounts accounts, LiquidateFullPosition2Params parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.LiquidateFullPosition2(accounts, parameters);
           return instr;
        }

     
        public async Task<TransactionInstruction> SendGetAddLiquidityAmountAndFeeAsync(GetAddLiquidityAmountAndFeeAccounts accounts, GetAddLiquidityAmountAndFeeParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetAddLiquidityAmountAndFee(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetRemoveLiquidityAmountAndFeeAsync(GetRemoveLiquidityAmountAndFeeAccounts accounts, GetRemoveLiquidityAmountAndFeeParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetRemoveLiquidityAmountAndFee(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetIncreasePositionAsync(GetIncreasePositionAccounts accounts, GetIncreasePositionParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetIncreasePosition(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetDecreasePositionAsync(GetDecreasePositionAccounts accounts, GetDecreasePositionParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetDecreasePosition(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetPnlAsync(GetPnlAccounts accounts, GetPnlAndFeeParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetPnl(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetLiquidationStateAsync(GetLiquidationStateAccounts accounts, GetLiquidationStateParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetLiquidationState(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetOraclePriceAsync(GetOraclePriceAccounts accounts)
        {
            TransactionInstruction instr = PerpetualsProgram.GetOraclePrice(accounts);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetSwapAmountAndFeesAsync(GetSwapAmountAndFeesAccounts accounts, GetSwapAmountAndFeesParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetSwapAmountAndFees(accounts, parameters);
           return instr;
        }

        public async Task<TransactionInstruction> SendGetExactOutSwapAmountAndFeesAsync(GetExactOutSwapAmountAndFeesAccounts accounts, GetExactOutSwapAmountAndFeesParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.GetExactOutSwapAmountAndFees(accounts, parameters);
           return instr;
        }

       
    }
}
