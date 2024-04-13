namespace MultiHospitalHarmony.Models.DTOs
{
	public class AddWardReq
	{
		public int Id { get; set; }
		public int WID { get; set; }
		public int HospitalId { get; set; }
		public string Name { get; set; }
		public int Type { get; set; }
		public int Capacity_of_bed { get; set; }
		public decimal Charge { get; set; }
	}
}
