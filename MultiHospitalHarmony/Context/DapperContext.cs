using Dapper;
using Microsoft.Data.SqlClient;
using MultiHospitalHarmony.Static;
using System.Data;

namespace MultiHospitalHarmony.Context
{
    public class DapperContext: IDapperContext
    {
        private SqlConnection _connection;
        public DapperContext()
        {
            _connection = new SqlConnection(DBConnection.SqlConnection);
        }
        public async Task<T> ExecuteProcAsync<T>(string Procname, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var result = _connection.QueryAsync<T>(Procname, param, commandType: commandType).Result;
            return result.FirstOrDefault();
        }
        public async Task<List<T>> GetAllAsync<T>(string Procname, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var result = await _connection.QueryAsync<T>(Procname, param, commandType: commandType);
            return result.ToList();
        }
        public async Task SaveLog(string classname, string method, string err)
        {
            string query = "insert into RunTimeError(ErrorClass,Error,ErrorMethod,EntryOn) values(@classname,@err,@method,Getdate())";
            var _ = _connection.ExecuteAsync(query, new
            {
                classname,
                err,
                method,
            }, commandType: CommandType.Text).Result;
        }
    }
}
