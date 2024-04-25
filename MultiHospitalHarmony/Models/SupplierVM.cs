namespace MultiHospitalHarmony.Models
{
    public class SupplierVM: Supplier
    {
        public List<City> City { get; set; } = new List<City>();
        public List<State> State { get; set; } = new List<State>();
    }
}
