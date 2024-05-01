using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IInvoiceService
    {
        Task<AppResponse<object>> Add(int loginId, AddInvoiceReq addInvoiceReq);
        Task<AppResponse<List<InvoiceItem>>> GetInvoiceItem(int loginId, GetInvoiceItemReq getInvoiceItemReq);
        Task<AppResponse<List<InvoiceList>>> GetInvoiceList(int loginId, GetInvoiceListReq getInvoiceListReq);
        Task<AppResponse<InvoiceDetails>> GetInvoiceDetail(int loginId, GetInvoiceDetailsReq getInvoiceDetailsReq);
    }
}
