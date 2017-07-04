using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jc_service_call_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace jc_service_call_api.Controllers
{
    public class ShiftsController : BaseController
    {
        private readonly IShiftRepository _shiftRepository;
        
        public ShiftsController(IShiftRepository shiftRepository)
        {
            this._shiftRepository = shiftRepository;
        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<Shift> Get()
        {
            return _shiftRepository.FindAll();
        }

        // GET api/shifts/5
        [HttpGet("{id}")]
        public Shift Get(int id)
        {
            return _shiftRepository.FindByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
