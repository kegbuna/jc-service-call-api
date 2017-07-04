using System.Collections.Generic;
using jc_service_call_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace jc_service_call_api.Controllers
{
    public class CallCodesController : BaseController
    {
        private readonly ICallCodeRepository _callCodeRepository;

        public CallCodesController(ICallCodeRepository callCodeRepository)
        {
            _callCodeRepository = callCodeRepository;
        }

        [HttpGet]
        public IEnumerable<CallCode> Get()
        {
            return _callCodeRepository.FindAll();
        }
    }
}