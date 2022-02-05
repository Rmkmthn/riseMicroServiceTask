using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rise.ContactCore.Models.HelperModels;
using Rise.ContactCore.Business;
using Rise.ContactCore.Models;

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

        [HttpGet("GetContacts")]
        public IActionResult GetContacts(int intRecordQty)
        {
            //pagination ve filtreleme icin islemler yapilabilir.
            var oQuery = _svcContact.GetContacts();

            List<Contact> lstContact = null;

            if (intRecordQty > 0)
            {
                lstContact = oQuery
                               .Skip(0)
                               .Take(intRecordQty)
                               .ToList();
            }
            else
            {
                lstContact = oQuery.ToList();
            }

            return Ok(lstContact);
        }

        [HttpGet("GetContactAndInfo")]
        public IActionResult GetContactAndInfo(Guid gID)
        {
            var oQuery = _svcContact.GetContactWithInfo(gID);

            return Ok(oQuery);
        }
    }
}
