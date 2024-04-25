using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
	public interface ICommonService
	{
		Task<AppResponse<List<MasterModule>>> GetModules(int UserId);
		Task<AppResponse<List<MasterMinus>>> GetSubMinus(int UserId);
		Task<AppResponse<DetailsByPincode>> GetDetailsByPincode(int pincode);
		Task<AppResponse<List<City>>> GetCity();
		Task<AppResponse<List<State>>> GetState();
		Task<AppResponse<List<ApplicationRole>>> GetUserRole(int loginId);
		Task<AppResponse<int>> VerifyHost(string hostName);
		Task<AppResponse<List<PaymentModes>>> GetPaymentModes();
    }
}
