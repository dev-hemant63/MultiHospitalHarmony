using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface ITransactionService
    {
        Task<AppResponse<InitateTxnRes>> InitateTxn(int loginId, decimal amount);
        Task<AppResponse<StatusCheckRes>> StatusCheck(int TID);
        Task<AppResponse<List<AddMoneyHistory>>> GetAddMoneyHistory(int loginId, int TID);
    }
}
