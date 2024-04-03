using Azure.Core;
using MultiHospitalHarmony.Context;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;
using ServiceStack.Web;
using System.Collections.Generic;
using System.Data;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDapperContext _dapperContext;
        public AppointmentService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<AppResponse<object>> Save(AppointmentReq request)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_SaveAppointment", request, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("AppointmentService", "Save", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<Appointments>>> GetAppointments(int loginId,AppointmentsFilter request)
        {
            var response = new AppResponse<List<Appointments>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Appointments>("Proc_GetAppointments", new
                {
                    request.FromDate,
                    request.ToDate,
                    request.SearchCriteria,
                    request.SearchText,
                    request.HospitalId,
                    request.DoctorId,
                }, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success.";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("AppointmentService", "GetAppointments", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<List<Appointments>>> GetScheduledAppointments(int loginId,AppointmentsFilter request)
        {
            var response = new AppResponse<List<Appointments>>();
            try
            {
                response.Data = await _dapperContext.GetAllAsync<Appointments>("Proc_GetScheduledAppointments", new
                {
                    request.FromDate,
                    request.ToDate,
                    request.SearchCriteria,
                    request.SearchText,
                    request.HospitalId,
                    request.DoctorId,
                }, CommandType.StoredProcedure);
                response.Success = true;
                response.Message = "Success.";
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("AppointmentService", "Proc_GetScheduledAppointments", ex.Message);
            }
            return response;
        }
        public async Task<AppResponse<object>> UpdateAppointmentStatus(int loginId,UpdateAppointmentReq request)
        {
            var response = new AppResponse<object>();
            try
            {
                response = await _dapperContext.ExecuteProcAsync<AppResponse<object>>("Proc_UpdateAppointmentStatus", new
                {
                    request.AppointmentId,
                    request.HospitalId,
                    request.DoctorId,
                    request.Status,
                    request.Remark,
                    loginId
                }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _dapperContext.SaveLog("AppointmentService", "UpdateAppointmentStatus", ex.Message);
            }
            return response;
        }
    }
}
