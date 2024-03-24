using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using MultiHospitalHarmony.Static;
using Newtonsoft.Json;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly IDapperContext _dapperContext;
        private readonly IApiUtilityService _apiUtilityService;
        public TransactionService(IDapperContext dapperContext, IApiUtilityService apiUtilityService)
        {
            _dapperContext = dapperContext;
            _apiUtilityService = apiUtilityService;
        }
        public async Task<AppResponse<InitateTxnRes>> InitateTxn(int loginId,decimal amount)
        {
            var res = new AppResponse<InitateTxnRes>();
            try
            {
                var Dbres = await _dapperContext.ExecuteProcAsync<AppResponse<int>>("Proc_InitiatePgTxn",new
                {
                    loginId,
                    amount
                }, CommandType.StoredProcedure);
                if (Dbres.Success)
                {
                    var pgReq = new
                    {
                        requestedId = Dbres.Data.ToString(),
                        amount = amount,
                        upiId = PgDetails.UpiId,
                        serverHookURL = PgDetails.ServerHookURL,
                        webHookURL = PgDetails.ServerHookURL,
                        merchantId = PgDetails.MerchantId,
                        secretkey = PgDetails.SecretKey,
                    };
                    var apiRes = _apiUtilityService.CallApiUsingPostWithHeader(PgDetails.TxnURL, pgReq,null);
                    if (!string.IsNullOrEmpty(apiRes))
                    {
                        var txnRes = JsonConvert.DeserializeObject<TxnRes>(apiRes);
                        if (txnRes.statusCode == 1)
                        {
                            res.Success = true;
                            res.Message = txnRes.responseText;
                            res.Data = new InitateTxnRes
                            {
                                URL = txnRes.result.url,
                                Display = txnRes.result.displayName,
                                TID = txnRes.result.transactionId
                            };
                        }
                        else
                        {
                            res.Message = txnRes.responseText;
                        }
                    }
                    else
                    {
                        res.Message = Dbres.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TransactionService", "InitateTxn", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<StatusCheckRes>> StatusCheck(int TID)
        {
            var res = new AppResponse<StatusCheckRes>();
            try
            {
                var txnDetails = await _dapperContext.ExecuteProcAsync<PgTransaction>("Select * from PgTransaction Where TID = @TID", new
                {
                    TID
                }, CommandType.StoredProcedure);
                if (txnDetails.Status == "P")
                {
                    var statusReq = new
                    {
                        tid = TID,
                        merchantId = PgDetails.MerchantId,
                        secretkey = PgDetails.SecretKey,
                    };
                    var apiRes = _apiUtilityService.CallApiUsingPostWithHeader(PgDetails.TxnURL, statusReq, null);
                    if (!string.IsNullOrEmpty(apiRes))
                    {
                        var txnStsRes = JsonConvert.DeserializeObject<StatusRes>(apiRes);
                        if (txnStsRes.statusCode == 1)
                        {
                            if (txnStsRes.status[0].ToString().ToUpper() != "P")
                            {
                                var Dbres = await _dapperContext.ExecuteProcAsync<AppResponse<int>>("Proc_UpdatePGTxn", new StatusCheckRes
                                {
                                    Status = txnStsRes.status,
                                    TID = TID,
                                    UTR = txnStsRes.utr
                                }, CommandType.StoredProcedure);
                            }
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TransactionService", "StatusCheck", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<AddMoneyHistory>>> GetAddMoneyHistory(int loginId,int TID)
        {
            var res = new AppResponse<List<AddMoneyHistory>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<AddMoneyHistory>("Proc_AddMoneyHistory", new
                {
                    loginId,
                    TID
                }, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TransactionService", "GetAddMoneyHistory", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<Ledger>>> GetLedger(int loginId)
        {
            var res = new AppResponse<List<Ledger>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<Ledger>("Proc_GetAccountLedger", new
                {
                    loginId,
                }, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TransactionService", "GetLedger", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> UpdateStatus(int TID, string status,string UTR)
        {
            var response = new AppResponse<object>
            {
                Message = "Sorry there is some issue!"
            };
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_UpdateTxnStatus", new
                {
                    status,
                    TID,
                    UTR
                }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("TransactionService", "UpdateStatus", ex.Message);
            }
            return response;
        }
    }
}
