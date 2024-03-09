using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class PgTransaction:CommonModel
    {
        public int UserId { get; set; }
        public int TID { get; set; }
        public int ServiceId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string UTR { get; set; }
        public string EntryAt { get; set; }
    }
}
