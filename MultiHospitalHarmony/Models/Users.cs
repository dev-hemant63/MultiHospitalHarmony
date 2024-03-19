using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Users:CommonModel
    {
        public int WId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int ZipCode { get; set; }
        public string Tehsil { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RedirectURL { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDedicated { get; set; }
        public decimal Balance { get; set; }
        public string CreatedAt { get; set; }
        public string Parent { get; set; }
        public string Qualifications { get; set; }
        public string HostName { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
    }
}
