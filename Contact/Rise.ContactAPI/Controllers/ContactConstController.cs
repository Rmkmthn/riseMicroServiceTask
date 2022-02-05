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
    public class ContactConstController : ControllerBase
    {
        IContactConstService _svcConst;
        public ContactConstController(IContactConstService svcConst)
        {
            _svcConst = svcConst;
        }
        [HttpGet("GetConsts")]
        public IActionResult GetConsts()
        {
            var oResult = _svcConst.GetConsts().ToList();

            return Ok(oResult);
        }

        [HttpGet("GetInfoTypes")]
        public IActionResult GetInfoTypes()
        {
            var oResult = _svcConst.GetInfoTypes().ToList();

            return Ok(oResult);
        }
    }
}
