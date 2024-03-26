using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using MultiHospitalHarmony.Static;
using Newtonsoft.Json;
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
        public async Task<AppResponse<object>> Create(Users users, int loginId,int WId)
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
                    users.HostName,
                    users.Logo,
                    users.Banner,
                    users.IsDedicated,
                    UserName = Utility.GetUserName((AppRole)users.RoleId),
                    EntryBy = loginId,
                    WId,
                    Qualifications = JsonConvert.DeserializeObject<DataTable>(users.Qualifications),
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
        public async Task<AppResponse<List<Users>>> GetUserList(int loginId, GetUserFilter userFilter)
        {
            var res = new AppResponse<List<Users>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<Users>("Proc_GetUserList", new
                {
                    loginId,
                    FilterRoleId = userFilter.RoleId,
                    userFilter.SearchCriteria,
                    userFilter.SearchText
                }, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "GetUserList", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<CreateUserVM>> GetUserById(int loginId, int Id)
        {
            var res = new AppResponse<CreateUserVM>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.ExecuteProcAsync<CreateUserVM>("Proc_GetUserList", new { loginId, Id }, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "GetUserList", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<Qualifications>>> GetUserQualifications(int loginId)
        {
            var res = new AppResponse<List<Qualifications>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<Qualifications>("Select * from Qualifications where UserId = @loginId", new { loginId }, CommandType.Text);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "GetUserQualifications", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<List<MedicalHistory>>> MedicalHistory(int loginId)
        {
            var res = new AppResponse<List<MedicalHistory>>
            {
                Message = "Failed."
            };
            try
            {
                res.Data = await _dapperContext.GetAllAsync<MedicalHistory>("Proc_MedicalHistory", new { loginId }, CommandType.StoredProcedure);
                res.Success = true;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "MedicalHistory", ex.Message);
            }
            return res;
        }
        public async Task<AppResponse<object>> SaveMedicalHistory(int loginId,MedicalHistory medicalHistory)
        {
            var response = new AppResponse<object>
            {
                Message = "Failed",
                Data = null
            };
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveMedicalHistory",new
                {
                    loginId,
                    medicalHistory.PatientId,
                    medicalHistory.Diagnosis,
                    medicalHistory.Prescription,
                    medicalHistory.PrescriptionFile,
                    medicalHistory.Wight,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("UserService", "SaveMedicalHistory", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<UserPermisions>>> GetPermisions(int UserId)
        {
            var response = new AppResponse<List<UserPermisions>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<UserPermisions>("Proc_GetPermisions", new
                {
                    UserId,
                });
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = "Sorry there is some issue.";
                _dapperContext.SaveLog("UserService", "GetPermisions", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<object>> AssignPermission(int UserId,int ModuleId)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AssignPermission", new
                {
                    UserId,
                    ModuleId
                });
            }
            catch (Exception ex)
            {
                response.Message = "Sorry there is some issue.";
                _dapperContext.SaveLog("UserService", "GetPermisions", ex.Message);
            }
            return response;
        }
    }
}
