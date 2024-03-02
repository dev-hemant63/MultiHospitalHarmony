using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Static;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IDapperContext _dapperContext;
        public UserService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> Create(Users users, int loginId)
        {
            var response = new AppResponse<object>
            {
                Success = false,
                Message = "An error has occurred; try again later.",
                Data = null
            };

            try
            {
                var result = await _dapperContext.ExecuteProcAsync<dynamic>("Proc_CreateUser", new
                {
                    users.Id,
                    users.RoleId,
                    users.FullName,
                    users.MobileNo,
                    users.Email,
                    Password = Security.Encrypt("123"),
                    users.Address,
                    users.CityId,
                    users.StateId,
                    users.ZipCode,
                    users.Tehsil,
                    UserName = Utility.GetUserName((AppRole)users.RoleId),
                    EntryBy = loginId,
                }, CommandType.StoredProcedure);
                response.Message = result.Message;
                if (result.StatusCode == 1)
                {
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "Create", ex.Message);
            }

            return response;
        }
        public async Task<AppResponse<List<Users>>> GetUserList(int loginId)
        {
            var res = new AppResponse<List<Users>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<Users>("Proc_GetUserList", new { loginId }, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "GetUserList", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<CreateUserVM>> GetUserById(int loginId,int Id)
        {
            var res = new AppResponse<CreateUserVM>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<CreateUserVM>("Proc_GetUserList", new { loginId,Id }, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "GetUserList", ex.Message);
            }
            return res;
        }
    }
}
