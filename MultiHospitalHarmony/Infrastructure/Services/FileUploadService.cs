using Azure;
using MultiHospitalHarmony.Infrastructure.Interfaces;
using MultiHospitalHarmony.Models;
using MultiHospitalHarmony.Models.Common;
using ServiceStack;
using System.Net.Http.Headers;
using System.Text;

namespace MultiHospitalHarmony.Infrastructure.Services
{
    public class FileUploadService: IFileUploadService
    {
        private readonly IRequestInfo _rinfo;
        public FileUploadService(IRequestInfo requestInfo)
        {
            _rinfo = requestInfo;
        }
        public AppResponse<string> Upload(FileUploadModel request)
        {
            var response = new AppResponse<string>
            {
                Message = "Failed to upload file."
            };
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(request.FilePath);
                if (!Directory.Exists(sb.ToString()))
                {
                    Directory.CreateDirectory(sb.ToString());
                }
                var filename = ContentDispositionHeaderValue.Parse(request.file.ContentDisposition).FileName.Trim('"');
                string originalExt = Path.GetExtension(filename).ToLower();
                string[] Extensions = { ".png", ".jpeg", ".jpg", ".webp", ".pdf" };
                if (!Extensions.Contains(originalExt))
                {
                    response.Message = "You can only upload JPEG, JPG, and PNG files.";
                    return response;
                }
                if (string.IsNullOrEmpty(request.FileName))
                {
                    request.FileName = filename;
                }
                sb.Append($"{request.FileName}{originalExt}");
                using (FileStream fs = File.Create(sb.ToString()))
                {
                    request.file.CopyTo(fs);
                    fs.Flush();
                }
                response.Success = true;
                response.Message = "Success";
                response.Data = $"{_rinfo.GetDomain()}/{request.FilePath.Replace("wwwroot/", "")}{request.FileName}{originalExt}";
            }
            catch (Exception ex)
            {
                response.Message = "Error in file uploading. Try after sometime...";
            }
            return response;
        }
    }
}
