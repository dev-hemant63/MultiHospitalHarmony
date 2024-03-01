using MultiHospitalHarmony.Models.Common;
using MultiHospitalHarmony.Models;

namespace MultiHospitalHarmony.Infrastructure.Interfaces
{
    public interface IFileUploadService
    {
        AppResponse<string> Upload(FileUploadModel request);
    }
}
