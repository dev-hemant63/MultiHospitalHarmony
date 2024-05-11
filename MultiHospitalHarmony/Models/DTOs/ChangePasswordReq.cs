using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
	public class ChangePasswordReq:CommonRequest
	{
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
