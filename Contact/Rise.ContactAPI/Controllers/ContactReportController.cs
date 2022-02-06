using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rise.ContactCore.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.ContractAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactReportController : ControllerBase
    {
        IContactReportService _svcContactReport;
        public ContactReportController(IContactReportService svcContactInfo)
        {
            _svcContactReport = svcContactInfo;
        }

        [HttpGet("GetReport00001Detail")]
        public IActionResult GetReport00001Detail()
        {
            var oResult = _svcContactReport.GetReport00001Detail();

            return Ok(oResult);
        }
    }
}
