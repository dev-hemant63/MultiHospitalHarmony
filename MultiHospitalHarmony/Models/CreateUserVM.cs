namespace MultiHospitalHarmony.Models
{
    public class CreateUserVM:Users
    {
        public List<City> City { get; set; }
        public List<State> State { get; set; }
        public List<ApplicationRole> ApplicationRole { get; set; }
    }
}
