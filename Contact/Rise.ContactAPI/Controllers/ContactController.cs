using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rise.ContactCore.Models.HelperModels;
using Rise.ContactCore.Business;

namespace Rise.ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService _svcContact;
        public ContactController(IContactService svcContact)
        {
            _svcContact = svcContact;
        }
        [HttpPost("Add")]
        public IActionResult AddContact([FromBody] ContactViewModel oNewContact)
        {
            var oResult = _svcContact.AddContact(oNewContact);

            return Ok(oResult);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteContact(Guid gID)
        {
            var blnResult = _svcContact.DeleteContact(gID);

            return Ok(blnResult);
        }
    }
}
