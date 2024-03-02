namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IApiUtilityService
    {
        string CallApiUsingGet(string URL);
        string CallApiUsingGetWithHeader(string URL, Dictionary<string, string> header);
        string CallApiUsingPostWithHeader(string URL, object body, Dictionary<string, string> header);
    }
}
