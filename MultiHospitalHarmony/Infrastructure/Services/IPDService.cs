using Azure.Core;
using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
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
    }
}
