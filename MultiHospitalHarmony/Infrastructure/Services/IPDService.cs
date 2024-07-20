using Azure.Core;
using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using Newtonsoft.Json;
using ServiceStack.Script;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class IPDService: IIPDService
    {
        private readonly IDapperContext _dapperContext;
        private readonly IUserService _userService;
        public IPDService(IDapperContext dapperContext, IUserService userService)
        {
            _dapperContext = dapperContext;
            _userService = userService;
        }
        public async Task<AppResponse<object>> AdmitPatient(int loginId,AdmitPatientReq req)
        {
            var response = new AppResponse<object>();
            try
            {
                if (string.IsNullOrEmpty(req.PatientUserName))
                {
                    var res = await _userService.Create(new Users
                    {
                        RoleId = 7,
                        FullName = req.FullName,
                        MobileNo = req.MobileNo,
                        Email = req.Email,
                        Address = req.Address,
                        CityId = 0,
                        StateId = req.State,
                        ZipCode = req.ZipCode,
                        Tehsil = req.Tehsil,
                    }, loginId, req.WID);
                    req.PatientUserName = res.Data.ToString();
                }
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_AdmitPatient", new
                {
                    req.PatientUserName,
                    req.DOB,
                    req.Age,
                    req.BloodGroup,
                    req.MaritalStatus,
                    req.Gender,
                    req.GuardianName,
                    req.GuardianMobile,
                    req.RelationWithPatient,
                    req.BloodPressure,
                    req.PulseRate,
                    req.Wight,
                    req.WardType,
                    req.RoomId,
                    req.BedId,
                    req.DoctorId,
                    req.PrescriptionFile,
                    req.Diagnosis,
                    req.Prescription,
                    loginId,
                    req.HospitalId,
                    req.WID,
                    req.ReferedType,
                    req.ReferedBY,
                    req.PreferredForAdmit,
                });
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("IPDService", "AdmitPatient", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<AdmitedPatientList>>> AdmitedPatientList(int loginId, PatientFilter patientFilter)
        {
            var response = new AppResponse<List<AdmitedPatientList>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<AdmitedPatientList>("Proc_GetAdmitedPatient", new
                {
                    patientFilter.HospitalId,
                    patientFilter.WID,
                    patientFilter.SearchCriteria,
                    patientFilter.SearchText
                }, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("IPDService", "AdmitedPatientList", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<DoctorVisit>>> GetDoctorVisit(int loginId, int patientId)
        {
            var response = new AppResponse<List<DoctorVisit>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<DoctorVisit>("Proc_GetDoctorVisit", new
                {
                    patientId
                }, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("IPDService", "GetDoctorVisit", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<PatientWardDetails>>> PatientWardDetails(int loginId, int patientId)
        {
            var response = new AppResponse<List<PatientWardDetails>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<PatientWardDetails>("Proc_GetPatientWardDetails", new
                {
                    patientId
                }, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("IPDService", "PatientWardDetails", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<object>> SaveDoctorVisit(int loginId, SaveDoctorVisitReq saveDoctorVisitReq)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveDoctorVisit",new
                {
                    loginId,
                    saveDoctorVisitReq.WID,
                    saveDoctorVisitReq.HospitalId,
                    saveDoctorVisitReq.DoctorId,
                    saveDoctorVisitReq.VisitDate,
                    saveDoctorVisitReq.VisitTime,
                    saveDoctorVisitReq.PatientId,
                },CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("IPDService", "SaveDoctorVisit", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<PatientDetails>> GetPatientDetails(int loginId, GetPatientDetailsReq getPatientDetailsReq)
        {
            var response = new AppResponse<PatientDetails>();
            try
            {
                var dbresponse = await _dapperContext.ExecuteProcAsync<AppResponse<string>>("Proc_GetPatientDetailsForRelease", new
                {
                    loginId,
                    getPatientDetailsReq.WID,
                    getPatientDetailsReq.HospitalId,
                    getPatientDetailsReq.PatientUserName
                },CommandType.StoredProcedure);
                response.Success = dbresponse.Success;
                response.Message = dbresponse.Message;
                response.Data = JsonConvert.DeserializeObject<List<PatientDetails>>(dbresponse.Data).FirstOrDefault();
                if (!string.IsNullOrEmpty(response.Data.WardDetailsJson)) {
					response.Data.WardDetails = JsonConvert.DeserializeObject<List<WardDetails>>(response.Data.WardDetailsJson);
				}
                if (!string.IsNullOrEmpty(response.Data.DoctorVisitJson))
                {
					response.Data.DoctorVisit = JsonConvert.DeserializeObject<List<DoctorVisitDetails>>(response.Data.DoctorVisitJson);
				}
				if (!string.IsNullOrEmpty(response.Data.MedicalHistoryJson))
                {
					response.Data.MedicalHistory = JsonConvert.DeserializeObject<List<MedicalHistoryDetails>>(response.Data.MedicalHistoryJson);
				}
				if (!string.IsNullOrEmpty(response.Data.SurgeriesDetailsJson))
                {
					response.Data.SurgeriesDetails = JsonConvert.DeserializeObject<List<SurgeriesDetails>>(response.Data.SurgeriesDetailsJson);
				}
                if (!string.IsNullOrEmpty(response.Data.HospitalServicesJson))
                {
                    response.Data.HospitalServices = JsonConvert.DeserializeObject<List<HospitalServices>>(response.Data.HospitalServicesJson);
                }
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("IPDService", "GetPatientDetails", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<object>> ReleasePatient(int loginId, PatientReleaseReq patientReleaseReq)
        {
            var res = new AppResponse<object>();
            try
            {
                res = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_ReleasePatient", new
                {
                    loginId,
                    patientReleaseReq.WID,
                    patientReleaseReq.HospitalId,
                    patientReleaseReq.PatientId,
                    patientReleaseReq.TotalAmount,
                    patientReleaseReq.Discount,
                    patientReleaseReq.InvoiceNo,
                    patientReleaseReq.PaymentModeId,
                    patientReleaseReq.BankId,
                    Services = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(patientReleaseReq.Services))
                },CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("IPDService", "ReleasePatient", ex.Message);
                res.Message = "An error has occurred try after sometime!";
            }
            return res;
        }
    }
}
