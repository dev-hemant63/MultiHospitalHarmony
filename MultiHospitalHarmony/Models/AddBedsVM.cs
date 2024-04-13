using MultiHospitalHarmony.Models.Common;

namespace MultiHospitalHarmony.Models
{
    public class AddBedsVM
    {
        public AppResponse<Wards> WardDetails { get; set; }
        public AppResponse<List<HospitalBeds>> HospitalBeds { get; set; }
    }
}
