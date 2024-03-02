using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using MultiHospitalHarmony.Static;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class AccountService: IAccountService
    {
        private readonly IDapperContext _dapperContext;
        public AccountService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<Users>> Login(LoginRequest loginRequest)
        {
            var response = new AppResponse<Users>
            {
                Success = false,
                Message = "An error has been occured try after sometime.",
                Data = null
            };
            try
            {
                loginRequest.Password = Security.Encrypt(loginRequest.Password);
                var result = await _dapperContext.ExecuteProcAsync<dynamic>("Proc_Login", loginRequest, CommandType.StoredProcedure);
                response.Message = result.Message;
                if (result.StatusCode == 1)
                {
                    response.Success = true;
                    response.Data = new Users
                    {
                        Id = result.Id,
                        RoleId = result.RoleId,
                        FullName = result.FullName,
                        MobileNo = result.MobileNo,
                        Email = result.Email,
                        Address = result.Address,
                        CityId = result.CityId,
                        StateId = result.StateId,
                        ZipCode = result.ZipCode,
                        Role = result.Role
                    };
                }
                else
                {
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("AccountService", "Login",ex.Message);
            }
            return response;
        }
    }
}
