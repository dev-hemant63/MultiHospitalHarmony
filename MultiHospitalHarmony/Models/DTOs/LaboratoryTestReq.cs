using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models.DTOs
{
    public class LaboratoryTestReq:CommonRequest
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public decimal Price { get; set; }
        public string EntryAt { get; set; }
    }
}
