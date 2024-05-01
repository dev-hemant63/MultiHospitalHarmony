using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface ICustomerService
    {
        Task<AppResponse<object>> Save(int loginId, AddUpdateCustomerReq addUpdateCustomerReq);
        Task<AppResponse<List<Customers>>> List(int loginId, GetCustomersReq getCustomersReq);
    }
}
