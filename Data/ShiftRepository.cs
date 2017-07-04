using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace jc_service_call_api.Data
{
    public interface IShiftRepository : IRepository<Shift>
    {
        
    }
    
    public class ShiftRepository : IShiftRepository
    {
        private readonly NpgsqlConnection _connection;
        
        public ShiftRepository(IOptions<DBInfo> dbInfo)
        {
            _connection = new NpgsqlConnection(dbInfo.Value.ConnectionString); 
        }

        public void Add(Shift item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Shift item)
        {
            throw new System.NotImplementedException();
        }

        public Shift FindByID(int shiftNumber)
        {
            var shift = _connection.Query<Shift>($"select shift_number ShiftNumber from shifts where shift_number = '{shiftNumber}' limit 1").AsList();

            if (!shift.Any()) {
                throw new HttpException(404, $"Shift not found by that id: {shiftNumber}");
            }

            return shift.First();
        }

        public IEnumerable<Shift> FindAll()
        {
            return _connection.Query<Shift>("select shift_number ShiftNumber from shifts");
        }
    }
}