using System.Collections.Generic;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace jc_service_call_api.Data
{
    public interface ICallCodeRepository : IRepository<CallCode>
    {
        
    }
    
    public class CallCodeRepository : ICallCodeRepository
    {
        private readonly NpgsqlConnection _connection;
        
        public CallCodeRepository(IOptions<DBInfo> dbInfo)
        {
            _connection = new NpgsqlConnection(dbInfo.Value.ConnectionString); 
        }
        
        public void Add(CallCode item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CallCode item)
        {
            throw new System.NotImplementedException();
        }

        public CallCode FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CallCode> FindAll()
        {
            return _connection.Query<CallCode>(
                "select pd_code PdCode, \"type\" \"Type\", description Description from call_codes");
        }
    }
}