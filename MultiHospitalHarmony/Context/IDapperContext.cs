using System.Data;

namespace MultiHospitalHarmony.Context
{
    public interface IDapperContext
    {
        Task<T> ExecuteProcAsync<T>(string Procname, object param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<List<T>> GetAllAsync<T>(string Procname, object param = null, CommandType commandType = CommandType.StoredProcedure);
        Task SaveLog(string classname, string method, string err);
    }
}
