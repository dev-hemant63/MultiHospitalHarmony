namespace MultiHospitalHarmony.Models.Common
{
    public class AppResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
