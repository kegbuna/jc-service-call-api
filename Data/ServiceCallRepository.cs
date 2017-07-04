using System.Collections.Generic;

namespace jc_service_call_api.Data
{
    public interface IServiceCallRepository : IRepository<ServiceCall>
    {
        
    }
    
    public class ServiceCallRepository : IServiceCallRepository
    {
        public void Add(ServiceCall item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ServiceCall item)
        {
            throw new System.NotImplementedException();
        }

        public ServiceCall FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceCall> FindAll()
        {
            throw new System.NotImplementedException();
        }
    }
}