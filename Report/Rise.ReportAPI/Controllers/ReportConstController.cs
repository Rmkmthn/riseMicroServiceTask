using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rise.ReportCore.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.ReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportConstController : ControllerBase
    {
        IReportConstService _svcConst;
        public ReportConstController(IReportConstService svcConst)
        {
            _svcConst = svcConst;
        }
        [HttpGet("GetConsts")]
        public IActionResult GetConsts()
        {
            var oResult = _svcConst.GetConsts().ToList();

            return Ok(oResult);
        }

        [HttpGet("GetReportStatuses")]
        public IActionResult GetReportStatuses()
        {
            var oResult = _svcConst.GetReportStatuses().ToList();

            return Ok(oResult);
        }
    }
}
