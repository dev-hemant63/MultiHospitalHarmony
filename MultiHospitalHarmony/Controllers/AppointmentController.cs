using Microsoft.AspNetCore.Mvc;
using MultiHospitalHarmony.Extentions;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.DTOs;

namespace MultiHospitalHarmony.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(AppointmentReq appointmentReq)
        {
            var response = await _appointmentService.Save(appointmentReq);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetAppointments(AppointmentsFilter filter)
        {
            filter.HospitalId = User.GetHospitalId();
            filter.DoctorId = User.GetDoctorId();
            var response = await _appointmentService.GetAppointments(User.GetLogingID<int>(),filter);
            return PartialView(response);
        }
        [HttpGet]
        public async Task<IActionResult> ScheduledAppointments()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetScheduledAppointments(AppointmentsFilter filter)
        {
            filter.HospitalId = User.GetHospitalId();
            filter.DoctorId = User.GetDoctorId();
            var response = await _appointmentService.GetScheduledAppointments(User.GetLogingID<int>(),filter);
            return PartialView(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentReq appointmentReq)
        {
            appointmentReq.HospitalId = User.GetHospitalId();
            appointmentReq.DoctorId = User.GetDoctorId();
            var response = await _appointmentService.UpdateAppointmentStatus(User.GetLogingID<int>(),appointmentReq);
            return Json(response);
        }
    }
}
