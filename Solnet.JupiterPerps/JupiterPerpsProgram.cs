using Solnet.JupiterPerps.Types;
using Solnet.Programs.Utilities;
using Solnet.Wallet;
using Solnet.Rpc.Models;
using Solnet.JupiterPerps.Records;

namespace Solnet.JupiterPerps
{
    public static class PerpetualsProgram
    {
        public static PublicKey programId = new PublicKey("PERPHjGBqRHArX4DySjwM6UJHiR3sWAatqfdBS2qQJu");
        public static PublicKey systemProgram = new PublicKey("11111111111111111111111111111111");
        public static PublicKey tokenProgram = new PublicKey("TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA");
        public static PublicKey associatedtokenProgram = new PublicKey("ATokenGPvbdGVxr1b2hvZbsiqW5xWH25efTNsLJA8knL");
        public static PublicKey wrappedSolAddress = new PublicKey("So11111111111111111111111111111111111111112");
        public static TransactionInstruction Init(InitAccounts accounts, InitParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.UpgradeAuthority, true), AccountMeta.ReadOnly(accounts.Admin, false), AccountMeta.Writable(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.PerpetualsProgram, false), AccountMeta.ReadOnly(accounts.PerpetualsProgramData, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7219264073434610652UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction AddPool(AddPoolAccounts accounts, AddPoolParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Admin, true), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12188765547744519795UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction AddCustody(AddCustodyAccounts accounts, AddCustodyParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Admin, true), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.CustodyTokenMint, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8491262331462811383UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction SetCustodyConfig(SetCustodyConfigAccounts accounts, SetCustodyConfigParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Admin, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Custody, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12692522363825316229UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction SetPoolConfig(SetPoolConfigAccounts accounts, SetPoolConfigParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Admin, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8699105588954617816UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction SetPerpetualsConfig(SetPerpetualsConfigAccounts accounts, SetPerpetualsConfigParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Admin, true), AccountMeta.Writable(accounts.Perpetuals, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8011192480828835920UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction TransferAdmin(TransferAdminAccounts accounts, TransferAdminParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Admin, true), AccountMeta.ReadOnly(accounts.NewAdmin, false), AccountMeta.Writable(accounts.Perpetuals, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(11272240368483234346UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction WithdrawFees2(WithdrawFees2Accounts accounts, WithdrawFees2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.ReceivingTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(14960920448027558140UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction CreateTokenMetadata(CreateTokenMetadataAccounts accounts, CreateTokenMetadataParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Admin, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.Metadata, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.TokenMetadataProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(4945159756801134813UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction CreateTokenLedger(CreateTokenLedgerAccounts accounts)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.TokenLedger, true), AccountMeta.Writable(accounts.Payer, true), AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(3783463427180458728UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction ReallocCustody(ReallocCustodyAccounts accounts)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Keeper, true), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(14474858947496721019UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction ReallocPool(ReallocPoolAccounts accounts)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Keeper, true), AccountMeta.Writable(accounts.Pool, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12837760634706034802UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction OperatorSetCustodyConfig(OperatorSetCustodyConfigAccounts accounts, OperatorSetCustodyConfigParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Operator, true), AccountMeta.Writable(accounts.Custody, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(15715557816512842150UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction OperatorSetPoolConfig(OperatorSetPoolConfigAccounts accounts, OperatorSetPoolConfigParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Operator, true), AccountMeta.Writable(accounts.Pool, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7635392228328786252UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction TestInit(TestInitAccounts accounts, TestInitParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.UpgradeAuthority, true), AccountMeta.ReadOnly(accounts.Admin, false), AccountMeta.Writable(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(2985907793612780336UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction SetTestTime(SetTestTimeAccounts accounts, SetTestTimeParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Admin, true), AccountMeta.Writable(accounts.Perpetuals, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7538904275816146930UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction SetTokenLedger(SetTokenLedgerAccounts accounts)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.TokenLedger, false), AccountMeta.ReadOnly(accounts.TokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(165875959599814116UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction Swap2(Swap2Accounts accounts, Swap2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.ReceivingCustody, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.ReceivingCustodyTokenAccount, false), AccountMeta.Writable(accounts.DispensingCustody, false), AccountMeta.ReadOnly(accounts.DispensingCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.DispensingCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.DispensingCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9825548078193527617UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction AddLiquidity2(AddLiquidity2Accounts accounts, AddLiquidity2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.Writable(accounts.LpTokenAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.Writable(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8319515505829257956UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction RemoveLiquidity2(RemoveLiquidity2Accounts accounts, RemoveLiquidity2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.Writable(accounts.LpTokenAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.Writable(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(10584415637148456934UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction CreateIncreasePositionMarketRequest(CreateIncreasePositionMarketRequestAccounts accounts, CreateIncreasePositionMarketRequestParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.InputMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(4079323830366459320UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction CreateDecreasePositionRequest2(CreateDecreasePositionRequest2Accounts accounts, CreateDecreasePositionRequest2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.DesiredMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5579131981675446377UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction CreateDecreasePositionMarketRequest(CreateDecreasePositionMarketRequestAccounts accounts, CreateDecreasePositionMarketRequestParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.DesiredMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5692941086008526410UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction UpdateDecreasePositionRequest2(UpdateDecreasePositionRequest2Accounts accounts, UpdateDecreasePositionRequest2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8429007239774849168UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction ClosePositionRequest(ClosePositionRequestAccounts accounts, ClosePositionRequestParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.Writable(accounts.Owner, false), AccountMeta.Writable(accounts.OwnerAta, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7957066542717954344UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction ClosePositionRequest2(ClosePositionRequest2Accounts accounts)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Keeper, true), AccountMeta.Writable(accounts.Owner, false), AccountMeta.Writable(accounts.OwnerAta, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(accounts.Mint, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(4812148807085212793UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction IncreasePosition4(IncreasePosition4Accounts accounts, IncreasePosition4Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(4832425257404306243UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction IncreasePositionPreSwap(IncreasePositionPreSwapAccounts accounts, IncreasePositionPreSwapParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.Writable(accounts.KeeperAta, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.Instruction, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(1464537491714443290UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction IncreasePositionWithInternalSwap(IncreasePositionWithInternalSwapAccounts accounts, IncreasePositionWithInternalSwapParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.Writable(accounts.ReceivingCustody, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.ReceivingCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.ReceivingCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8079701580626671474UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction DecreasePosition4(DecreasePosition4Accounts accounts, DecreasePosition4Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.Writable(accounts.Owner, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12250798554359177657UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction DecreasePositionWithInternalSwap(DecreasePositionWithInternalSwapAccounts accounts, DecreasePositionWithInternalSwapParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.Writable(accounts.Owner, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.Writable(accounts.DispensingCustody, false), AccountMeta.ReadOnly(accounts.DispensingCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.DispensingCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.DispensingCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(2765602110301606275UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction DecreasePositionWithTpsl(DecreasePositionWithTpslAccounts accounts, DecreasePositionWithTpslParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.Owner, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(11907913117919285868UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction DecreasePositionWithTpslAndInternalSwap(DecreasePositionWithTpslAndInternalSwapAccounts accounts, DecreasePositionWithTpslAndInternalSwapParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.Owner, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.Writable(accounts.DispensingCustody, false), AccountMeta.ReadOnly(accounts.DispensingCustodyDovesPriceAccount, false), AccountMeta.Writable(accounts.DispensingCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16968227643516808962UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction LiquidateFullPosition4(LiquidateFullPosition4Accounts accounts, LiquidateFullPosition4Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Signer, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12654196483606229056UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction RefreshAssetsUnderManagement(RefreshAssetsUnderManagementAccounts accounts, RefreshAssetsUnderManagementParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(52090330670366882UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction SetMaxGlobalSizes(SetMaxGlobalSizesAccounts accounts, SetMaxGlobalSizesParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.Pool, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(15424234605629276761UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction InstantCreateTpsl(InstantCreateTpslAccounts accounts, InstantCreateTpslParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.ApiKeeper, true), AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.DesiredMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13351257676882010741UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction InstantCreateLimitOrder(InstantCreateLimitOrderAccounts accounts, InstantCreateLimitOrderParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.ApiKeeper, true), AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.Writable(accounts.PositionRequestAta, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.InputMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(11276590328834106818UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction InstantIncreasePosition(InstantIncreasePositionAccounts accounts, InstantIncreasePositionParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.ApiKeeper, true), AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.FundingAccount, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenLedger, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13204737587216154276UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction InstantDecreasePosition(InstantDecreasePositionAccounts accounts, InstantDecreasePositionParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.ApiKeeper, true), AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.ReceivingAccount, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.Writable(accounts.Pool, false), AccountMeta.Writable(accounts.Position, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustody, false), AccountMeta.ReadOnly(accounts.CollateralCustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CollateralCustodyPythnetPriceAccount, false), AccountMeta.Writable(accounts.CollateralCustodyTokenAccount, false), AccountMeta.ReadOnly(accounts.DesiredMint, false), AccountMeta.ReadOnly(accounts.Referral, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(10114673675328296750UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction InstantUpdateLimitOrder(InstantUpdateLimitOrderAccounts accounts, InstantUpdateLimitOrderParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.ApiKeeper, true), AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(14919455217390318984UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction InstantUpdateTpsl(InstantUpdateTpslAccounts accounts, InstantUpdateTpslParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Keeper, true), AccountMeta.ReadOnly(accounts.ApiKeeper, true), AccountMeta.ReadOnly(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Position, false), AccountMeta.Writable(accounts.PositionRequest, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7309327511357416592UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction GetAddLiquidityAmountAndFee2(GetAddLiquidityAmountAndFee2Accounts accounts, GetAddLiquidityAmountAndFee2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8504011094022921581UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction GetRemoveLiquidityAmountAndFee2(GetRemoveLiquidityAmountAndFee2Accounts accounts, GetRemoveLiquidityAmountAndFee2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.CustodyDovesPriceAccount, false), AccountMeta.ReadOnly(accounts.CustodyPythnetPriceAccount, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(10274667740845849527UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction GetAssetsUnderManagement2(GetAssetsUnderManagement2Accounts accounts, GetAssetsUnderManagement2Params instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(6061164990252831425UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction BorrowFromCustody(BorrowFromCustodyAccounts accounts, BorrowFromCustodyParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.BorrowPosition, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.Writable(accounts.UserTokenAccount, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(3312715771217557401UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction RepayToCustody(RepayToCustodyAccounts accounts, RepayToCustodyParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.Writable(accounts.BorrowPosition, false), AccountMeta.Writable(accounts.CustodyTokenAccount, false), AccountMeta.Writable(accounts.UserTokenAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(1874987252618615763UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction DepositCollateralForBorrows(DepositCollateralForBorrowsAccounts accounts, DepositParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.ReadOnly(accounts.Custody, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.BorrowPosition, false), AccountMeta.Writable(accounts.CollateralTokenAccount, false), AccountMeta.Writable(accounts.UserTokenAccount, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5399270925067813393UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction WithdrawCollateralForBorrows(WithdrawCollateralForBorrowsAccounts accounts, WithdrawParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.BorrowPosition, false), AccountMeta.Writable(accounts.CollateralTokenAccount, false), AccountMeta.Writable(accounts.UserTokenAccount, false), AccountMeta.ReadOnly(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13127687169327800437UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction LiquidateBorrowPosition(LiquidateBorrowPositionAccounts accounts, LiquidateBorrowPositionParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Signer, true), AccountMeta.ReadOnly(accounts.Perpetuals, false), AccountMeta.ReadOnly(accounts.Pool, false), AccountMeta.Writable(accounts.Custody, false), AccountMeta.ReadOnly(accounts.TransferAuthority, false), AccountMeta.Writable(accounts.BorrowPosition, false), AccountMeta.Writable(accounts.CollateralTokenAccount, false), AccountMeta.Writable(accounts.LpTokenMint, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(15155818818100644331UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static TransactionInstruction CloseBorrowPosition(CloseBorrowPositionAccounts accounts, CloseBorrowPositionParams instruct_params)
            {
                List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Owner, true), AccountMeta.Writable(accounts.BorrowPosition, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.EventAuthority, false), AccountMeta.ReadOnly(accounts.Program, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(10088949272051573452UL, offset);
                offset += 8;
                offset += instruct_params.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

    
    }
}
