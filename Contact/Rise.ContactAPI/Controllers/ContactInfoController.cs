using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rise.ContactCore.Business;
using Rise.ContactCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.ContractAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        IContactInfoService _svcContactInfo;
        public ContactInfoController(IContactInfoService svcContactInfo)
        {
            _svcContactInfo = svcContactInfo;
        }
        [HttpPost("SaveContactInfo")]
        public IActionResult AddContactInfo([FromBody] ContactInfo oContactInfo)
        {
            var oResult = _svcContactInfo.SaveContactInfo(oContactInfo);

            return Ok(oResult);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteContactInfo(Guid gID)
        {
            var blnResult = _svcContactInfo.DeleteContactInfo(gID);

            return Ok(blnResult);
        }
    }
}
