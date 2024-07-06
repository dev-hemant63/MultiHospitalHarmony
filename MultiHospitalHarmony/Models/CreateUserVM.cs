namespace MultiHospitalHarmony.Models
{
    public class CreateUserVM:Users
    {
        public List<City> City { get; set; } = new List<City>();
        public List<State> State { get; set; } = new List<State>();
        public List<ApplicationRole> ApplicationRole { get; set; } = new List<ApplicationRole>();
        public List<Users> UserList { get; set; } = new List<Users>();
        public List<WardType> WardType { get; set; } = new List<WardType>();
    }
}
