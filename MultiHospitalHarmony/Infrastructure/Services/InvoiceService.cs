using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class InvoiceService: IInvoiceService
    {
        private readonly IDapperContext _dapperContext;
        public InvoiceService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> Add(int loginId, AddInvoiceReq addInvoiceReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddInvoice",new
                {
                    loginId,
                    addInvoiceReq.WID,
                    addInvoiceReq.HospitalId,
                    addInvoiceReq.CustomerId,
                    addInvoiceReq.InvoiceDate,
                    addInvoiceReq.Details,
                    addInvoiceReq.PaymentModeId,
                    addInvoiceReq.Remark,
                    addInvoiceReq.Discount,
                    addInvoiceReq.GST,
                    addInvoiceReq.TotalAmount,
                    addInvoiceReq.PaidAmount,
                    addInvoiceReq.BalanceAmount,
                    addInvoiceReq.SubTotalAmount,
                    InvoicesItems = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(addInvoiceReq.InvoicesItems))
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "Add", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<InvoiceItem>>> GetInvoiceItem(int loginId, GetInvoiceItemReq getInvoiceItemReq)
        {
            var res = new AppResponse<List<InvoiceItem>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<InvoiceItem>("Proc_GetInvoiceItem",new
                {
                    getInvoiceItemReq.WID,
                    getInvoiceItemReq.HospitalId,
                    loginId
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "GetInvoiceItem", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<InvoiceList>>> GetInvoiceList(int loginId, GetInvoiceListReq getInvoiceListReq)
        {
            var res = new AppResponse<List<InvoiceList>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<InvoiceList>("Proc_GetInvoiceList", new
                {
                    getInvoiceListReq.WID,
                    getInvoiceListReq.HospitalId,
                    loginId
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "GetInvoiceList", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<InvoiceDetails>> GetInvoiceDetail(int loginId, GetInvoiceDetailsReq getInvoiceDetailsReq)
        {
            var res = new AppResponse<InvoiceDetails>();
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<InvoiceDetails>("Proc_GetInvoiceDetails", new
                {
                    getInvoiceDetailsReq.WID,
                    getInvoiceDetailsReq.HospitalId,
                    getInvoiceDetailsReq.InvoiceId,
                    loginId
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "GetInvoiceDetail", ex.Message);
            }
            return res;
        }
    }
}
