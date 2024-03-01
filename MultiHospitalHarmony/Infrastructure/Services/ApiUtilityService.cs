using MultiHospitalHarmony.Infrastructure.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class ApiUtilityService: IApiUtilityService
    {
        public string CallApiUsingGet(string URL)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(URL);
                http.Method = "GET";
                http.ContentType = "application/json";
                WebResponse response = http.GetResponse();
                using (StreamReader str = new StreamReader(response.GetResponseStream()))
                {
                    result = str.ReadToEnd();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public string CallApiUsingGetWithHeader(string URL, Dictionary<string, string> header)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(URL);
                http.Method = "GET";
                http.ContentType = "application/json";
                foreach (var item in header)
                {
                    http.Headers.Add(item.Key, item.Value);
                }
                WebResponse response = http.GetResponse();
                using (StreamReader str = new StreamReader(response.GetResponseStream()))
                {
                    result = str.ReadToEnd();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public string CallApiUsingPostWithHeader(string URL, object body, Dictionary<string, string> header = null)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(URL);
                http.Method = "POST";
                http.ContentType = "application/json";
                var requestbody = JsonConvert.SerializeObject(body);
                var data = Encoding.Default.GetBytes(requestbody);
                http.ContentLength = data.Length;
                if(header != null)
                {
                    foreach (var item in header)
                    {
                        http.Headers.Add(item.Key, item.Value);
                    }
                }
                
                using (Stream requestStream = http.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
                WebResponse response = http.GetResponse();
                using (StreamReader str = new StreamReader(response.GetResponseStream()))
                {
                    result = str.ReadToEnd();
                }
            }
            catch (System.Exception)
            {
                result = "CreateAccount";
            }
            return result;
        }
    }
}
