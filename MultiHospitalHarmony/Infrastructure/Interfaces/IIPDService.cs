using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IIPDService
    {
        Task<AppResponse<object>> AdmitPatient(int loginId, AdmitPatientReq req);
        Task<AppResponse<List<AdmitedPatientList>>> AdmitedPatientList(int loginId, PatientFilter patientFilter);
        Task<AppResponse<List<DoctorVisit>>> GetDoctorVisit(int loginId, int patientId);
        Task<AppResponse<List<PatientWardDetails>>> PatientWardDetails(int loginId, int patientId);
        Task<AppResponse<object>> SaveDoctorVisit(int loginId, SaveDoctorVisitReq saveDoctorVisitReq);
    }
}
