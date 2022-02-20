using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Contact.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult NotValid(object model = null) 
        {
            var errors = ModelState.Values.Where(w => w.Errors.Count > 0).SelectMany(s => s.Errors).Select(s => s.ErrorMessage).ToList();
            IDataResult<object> result = new ErrorDataResult<object>(model, errors);

            return BadRequest(result);
        }
    }
}
