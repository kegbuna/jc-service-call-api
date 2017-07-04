using System.Collections.Generic;
using jc_service_call_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace jc_service_call_api.Controllers
{
    public interface ICallService
    {
        IEnumerable<CallCode> Get();
    }
    
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        
    }
}