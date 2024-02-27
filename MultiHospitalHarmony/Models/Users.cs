using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Users:CommonModel
    {
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int ZipCode { get; set; }
        public string Photo { get; set; }
        public string Role { get; set; }
        public string RedirectURL { get; set; }
    }
}
