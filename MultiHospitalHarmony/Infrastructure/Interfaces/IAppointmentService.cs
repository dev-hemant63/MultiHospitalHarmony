using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppResponse<object>> Save(AppointmentReq request);
        Task<AppResponse<List<Appointments>>> GetAppointments(int loginId, AppointmentsFilter request);
        Task<AppResponse<object>> UpdateAppointmentStatus(int loginId,UpdateAppointmentReq request);
    }
}
