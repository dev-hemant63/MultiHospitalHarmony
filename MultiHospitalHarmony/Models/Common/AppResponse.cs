namespace MultiHospitalHarmony.Models.Common
{
    public class AppResponse<T>
    {
        public AppResponse() {
            this.Message = "Something went wrong try after sometime!";
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
