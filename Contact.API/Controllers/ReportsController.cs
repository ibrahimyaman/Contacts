using Contact.Bussiness.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult GetAllReports()
        {
            return Ok(_reportService.GetAll());
        }
        [HttpGet("{uuid:guid}")]
        public IActionResult GetReportById(Guid uuid)
        {
            var result = _reportService.GetByUuid(uuid);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("createnewreport")]
        public IActionResult CreateNewReport()
        {
            var result = _reportService.CreateReport();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
