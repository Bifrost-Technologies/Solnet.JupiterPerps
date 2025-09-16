using Solnet.JupiterPerps.Types;
using Solnet.JupiterPerps.Records;
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

        public async Task<ProgramAccountsResultWrapper<List<Custody>>> GetCustodysAsync( Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Custody.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(PerpetualsProgram.programId, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Custody>>(res);
            List<Custody> resultingAccounts = new List<Custody>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Custody.Deserialize(Convert.FromBase64String(result.Account.Data[0]))!));
            return new ProgramAccountsResultWrapper<List<Custody>>(res, resultingAccounts);
        }


        public async Task<ProgramAccountsResultWrapper<List<Perpetuals>>> GetPerpetualssAsync( Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Perpetuals.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(PerpetualsProgram.programId, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Perpetuals>>(res);
            List<Perpetuals> resultingAccounts = new List<Perpetuals>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Perpetuals.Deserialize(Convert.FromBase64String(result.Account.Data[0]))!));
            return new ProgramAccountsResultWrapper<List<Perpetuals>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<Pool>>> GetPoolsAsync( Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Pool.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(PerpetualsProgram.programId, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Pool>>(res);
            List<Pool> resultingAccounts = new List<Pool>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Pool.Deserialize(Convert.FromBase64String(result.Account.Data[0]))!));
            return new ProgramAccountsResultWrapper<List<Pool>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<PositionRequest>>> GetPositionRequestsAsync( Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = PositionRequest.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(PerpetualsProgram.programId, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<PositionRequest>>(res);
            List<PositionRequest> resultingAccounts = new List<PositionRequest>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => PositionRequest.Deserialize(Convert.FromBase64String(result.Account.Data[0]))!));
            return new ProgramAccountsResultWrapper<List<PositionRequest>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<Position>>> GetPositionsAsync( Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Position.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(PerpetualsProgram.programId, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Position>>(res);
            List<Position> resultingAccounts = new List<Position>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Position.Deserialize(Convert.FromBase64String(result.Account.Data[0]))!));
            return new ProgramAccountsResultWrapper<List<Position>>(res, resultingAccounts);
        }

        public async Task<AccountResultWrapper<Custody>> GetCustodyAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Custody>(res);
            var resultingAccount = Custody.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Custody>(res, resultingAccount!);
        }

        public async Task<AccountResultWrapper<Perpetuals>> GetPerpetualsAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Perpetuals>(res);
            var resultingAccount = Perpetuals.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Perpetuals>(res, resultingAccount!);
        }

        public async Task<AccountResultWrapper<Pool>> GetPoolAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Pool>(res);
            var resultingAccount = Pool.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Pool>(res, resultingAccount!);
        }

        public async Task<AccountResultWrapper<PositionRequest>> GetPositionRequestAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<PositionRequest>(res);
            var resultingAccount = PositionRequest.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<PositionRequest>(res, resultingAccount!);
        }

        public async Task<AccountResultWrapper<Position>> GetPositionAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Position>(res);
            var resultingAccount = Position.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Position>(res, resultingAccount!);
        }

      


        public async Task<string> SendCreateIncreasePositionAsync(Account tradingAccount, ulong collateral_sol_amount, CreateIncreasePositionMarketRequestAccounts instruction_accounts, CreateIncreasePositionMarketRequestParams parameters)
        {
            TransactionInstruction test = PerpetualsProgram.CreateIncreasePositionMarketRequest(instruction_accounts, parameters);
            TransactionInstruction transfer = SystemProgram.Transfer(tradingAccount.PublicKey, AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(tradingAccount.PublicKey, PerpetualsProgram.wrappedSolAddress), collateral_sol_amount);
            TransactionInstruction syncSol = TokenProgram.SyncNative(AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(tradingAccount.PublicKey, PerpetualsProgram.wrappedSolAddress));
            LatestBlockHash latestBlockHash = RpcClient.GetLatestBlockHash().Result.Value;
            TransactionBuilder TB = new TransactionBuilder();
            TB.AddInstruction(ComputeBudgetProgram.SetComputeUnitLimit(100000));
            TB.AddInstruction(ComputeBudgetProgram.SetComputeUnitPrice(5000));
            TB.AddInstruction(AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(tradingAccount.PublicKey, tradingAccount.PublicKey, PerpetualsProgram.wrappedSolAddress));
            TB.AddInstruction(transfer);
            TB.AddInstruction(syncSol);
            TB.AddInstruction(test);
            TB.SetRecentBlockHash(latestBlockHash.Blockhash);
            TB.SetFeePayer(tradingAccount.PublicKey);
            byte[] signedTX = TB.Build(tradingAccount);

            var tx = await RpcClient.SendTransactionAsync(signedTX);
            return tx.RawRpcResponse;
        }

     

        public TransactionInstruction SendClosePositionAsync(ClosePositionRequestAccounts accounts, ClosePositionRequestParams parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.ClosePositionRequest(accounts, parameters);
           return instr;
        }

     
        public TransactionInstruction SendLiquidateFullPosition2Async(LiquidateFullPosition4Accounts accounts, LiquidateFullPosition4Params parameters)
        {
            TransactionInstruction instr = PerpetualsProgram.LiquidateFullPosition4(accounts, parameters);
           return instr;
        }

       
    }
}
