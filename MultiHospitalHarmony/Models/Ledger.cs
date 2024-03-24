using MultiHospitalHarmony.Enum;
using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class Ledger:CommonModel
    {
        public int TID { get; set; }
        public string UserInfo { get; set; }
        public string ServiceName { get; set; }
        public decimal Opening { get; set; }
        public decimal Amount { get; set; }
        public decimal Closing { get; set; }
        public TrType TrType { get; set; }
        public string EntryAt { get; set; }
        public string Reference { get; set; }
    }
}
