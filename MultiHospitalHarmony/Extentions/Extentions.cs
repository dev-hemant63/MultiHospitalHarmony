using System.Security.Claims;

namespace MultiHospitalHarmony.Extentions
{
	public static class Extentions
	{
		public static string GetLoginEmail(this ClaimsPrincipal claimsPrincipal)
		{
			var Userid = claimsPrincipal.FindFirst(ClaimTypes.Email);
			return Userid.Value;
		}
		public static string GetLoginName(this ClaimsPrincipal claimsPrincipal)
		{
			var Userid = claimsPrincipal.FindFirst(ClaimTypes.Name);
			return Userid.Value;
		}
		public static string GetLoginUserRole(this ClaimsPrincipal claimsPrincipal)
		{
			var Userid = claimsPrincipal.FindFirst(ClaimTypes.Role);
			return Userid.Value;
		}
		public static string GetLoginUserProfile(this ClaimsPrincipal claimsPrincipal)
		{
			var Userid = claimsPrincipal.FindFirst("Profile");
			return Userid.Value;
		}
		public static T GetLogingID<T>(this ClaimsPrincipal claimsPrincipal)
		{
			var Userid = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
			return (T)Convert.ChangeType(Userid.Value, typeof(T));
		}
	}
}
