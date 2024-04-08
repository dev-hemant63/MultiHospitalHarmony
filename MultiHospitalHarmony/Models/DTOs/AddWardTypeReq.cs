namespace MultiHospitalHarmony.Models.DTOs
{
	public class AddWardTypeReq
	{
		public int Id { get; set; }
		public int WID { get; set; }
		public int HospitalId { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
	}
}
