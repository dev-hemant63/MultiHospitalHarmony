using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IDapperContext _dapperContext;
        public CustomerService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> Save(int loginId, AddUpdateCustomerReq addUpdateCustomerReq)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AddUpdateCustomer", new
                {
                    loginId,
                    addUpdateCustomerReq.Id,
                    addUpdateCustomerReq.WID,
                    addUpdateCustomerReq.HospitalId,
                    addUpdateCustomerReq.Name,
                    addUpdateCustomerReq.MobileNo,
                    addUpdateCustomerReq.EmailId,
                    addUpdateCustomerReq.Pincode,
                    addUpdateCustomerReq.CityId,
                    addUpdateCustomerReq.StateId,
                    addUpdateCustomerReq.Tahsil,
                    addUpdateCustomerReq.Address,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CustomerService", "Save", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<Customers>>> List(int loginId, GetCustomersReq getCustomersReq)
        {
            var response = new AppResponse<List<Customers>>
            {
                Message = "Failed."
            };
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Customers>("Proc_GetCustomers", new
                {
                    loginId,
                    getCustomersReq.Id,
                    getCustomersReq.WID,
                    getCustomersReq.HospitalId,
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("CustomerService", "List", ex.Message);
            }
            return response;
        }
    }
}
