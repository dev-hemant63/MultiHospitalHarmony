using Azure.Core;
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
                    getInvoiceListReq.StatusId,
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
        public async Task<AppResponse<object>> CancelReturnSale(int loginId, ReturnSaleReq request)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_ReturnInvoice", new
                {
                    loginId,
                    request.WID,
                    request.HospitalId,
                    InvoiceId = request.Id,
                }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "CancelReturnSale", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<SaleReportMonthWise>>> GetSaleReportMonthWise(int loginId, GetSaleReportMonthWiseReq reportMonthWiseReq)
        {
            var res = new AppResponse<List<SaleReportMonthWise>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<SaleReportMonthWise>("Proc_GetSaleReportMonthWise", new
                {
                    reportMonthWiseReq.WID,
                    reportMonthWiseReq.HospitalId,
                    reportMonthWiseReq.Year,
                    loginId
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "GetSaleReportMonthWise", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<SaleReportMonthWise>>> GetPurchaseReportMonthWise(int loginId, GetSaleReportMonthWiseReq reportMonthWiseReq)
        {
            var res = new AppResponse<List<SaleReportMonthWise>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<SaleReportMonthWise>("Proc_GetPurchaseReportMonthWise", new
                {
                    reportMonthWiseReq.WID,
                    reportMonthWiseReq.HospitalId,
                    reportMonthWiseReq.Year,
                    loginId
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "GetPurchaseReportMonthWise", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> AddLaboratory_Invoice(int loginId,Laboratory_InvoiceReq request)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_Laboratory_Invoice", new
                {
                    loginId,
                    request.WID,
                    request.HospitalId,
                    request.PatientId,
                    request.InvoiceDate,
                    request.Details,
                    request.PaymentModeId,
                    request.Remark,
                    request.SubTotal,
                    request.Discount,
                    request.GST,
                    request.TotalAmount,
                    request.PaidAmount,
                    request.BalanceAmount,
                    Laboratory_Invoice_Details = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(request.Laboratory_Invoice_Details)),
                }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "AddLaboratory_Invoice", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<Laboratory_Invoice>>> GetLaboratory_InvoiceList(int loginId, GetLaboratory_InvoiceReq getLaboratory)
        {
            var res = new AppResponse<List<Laboratory_Invoice>>();
            try
            {
                res.Data = await _dapperContext.GetAllAsync<Laboratory_Invoice>("Proc_GetLaboratory_InvoiceList", new
                {
                    getLaboratory.WID,
                    getLaboratory.HospitalId,
                    loginId
                });
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("InvoiceService", "GetLaboratory_InvoiceList", ex.Message);
            }
            return res;
        }
    }
}
