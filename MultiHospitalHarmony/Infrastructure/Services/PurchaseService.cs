using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class PurchaseService: IPurchaseService
    {
        private readonly IDapperContext _dapperContext;
        public PurchaseService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> SaveMedicinePurchase(int LoginId, MedicinePurchaseReq medicinePurchaseReq)
        {
            var response = new AppResponse<object>();
            try
            {
                string MedicinePurchaseDetails = JsonConvert.SerializeObject(medicinePurchaseReq.MedicinePurchaseDetails);
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveMedicinePurchase", new
                {
                    LoginId,
                    medicinePurchaseReq.WID,
                    medicinePurchaseReq.HospitalId,
                    PharmacyId = LoginId,
                    medicinePurchaseReq.SupplierId,
                    medicinePurchaseReq.InvoiceNo,
                    medicinePurchaseReq.PaymentTypeId,
                    medicinePurchaseReq.PurchaseDate,
                    medicinePurchaseReq.Details,
                    medicinePurchaseReq.Remark,
                    medicinePurchaseReq.TotalAmount,
                    medicinePurchaseReq.PaidAmount,
                    medicinePurchaseReq.Discount,
                    medicinePurchaseReq.SubTotalAmount,
                    medicinePurchaseReq.BalanceAmount,
                    MedicinePurchaseDetails = JsonConvert.DeserializeObject<DataTable>(MedicinePurchaseDetails)
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("PurchaseService", "SaveMedicinePurchase", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<MedicinePurchase>>> GetMedicinePurchase(int loginId, GetMedicinePurchasReq request)
        {
            var response = new AppResponse<List<MedicinePurchase>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<MedicinePurchase>("Proc_GetMedicinePurchase", new
                {
                    loginId,
                    request.WID,
                    request.HospitalId
                }, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success.";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("PurchaseService", "GetMedicinePurchase", ex.Message);
            }
            return response;
        }
    }
}
