using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Contact.API.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        public IActionResult ServerError()
        {
            return Content(JsonConvert.SerializeObject(new ErrorDataResult<object>("Unexpected Server Error")), "application/json");
        }
    }
}
