using MultiHospitalHarmony.Models;
using Newtonsoft.Json;
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
		public static T GetLogingID<T>(this ClaimsPrincipal claimsPrincipal)
		{
			var Userid = claimsPrincipal.FindFirst("UserId");
			return (T)Convert.ChangeType(Userid.Value, typeof(T));
		}
		public static T GetRoleId<T>(this ClaimsPrincipal claimsPrincipal)
		{
			var Userid = claimsPrincipal.FindFirst("RoleId");
			return (T)Convert.ChangeType(Userid.Value, typeof(T));
		}
		public static MinusVM GetMenu(this ClaimsPrincipal claimsPrincipal)
		{
			var json = claimsPrincipal.FindFirst("Menus");
			var data = JsonConvert.DeserializeObject<MinusVM>(json.Value);
			return data;

        }
        public static string GetBalance(this ClaimsPrincipal claimsPrincipal)
        {
            var Userid = claimsPrincipal.FindFirst("Balance");
            return Userid.Value.ToString();
        }
    }
}
