using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test01_SERVICES.Models.Data;
using test01_SERVICES.Models;
using Microsoft.EntityFrameworkCore;
using test01_SERVICES.Utils;

namespace test01_SERVICES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly test01Context _context;

        public ContactController(test01Context context)
        {
            _context = context;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<object>> GetContact()
        {
            genericJsonResponse response = new();
            List<Contact> contacts = new();
            try
            {
                contacts = await _context.Contacts.Where(c => c.Disabled == false).ToListAsync();
                response.success = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            finally
            {
                response.data = contacts;
            }
            return response;
        }


        [HttpPost]
        public async Task<ActionResult<object>> PostContact([FromBody] genericJsonRequest request)
        {
            genericJsonResponse response = new();
            Contact contactParsed = JSON.Parse<Contact>(request.stringify);
            Contact contact;
            try
            {
                response.success = true;
                switch (request.operation)
                {
                    case CONSTANT.CREATE:
                        await _context.Contacts.AddAsync(contactParsed);
                        response.message = "created: done";
                        break;

                    case CONSTANT.EDIT:
                        contact = await _context.Contacts.FindAsync(contactParsed.Id);
                        contact.FirstName = contactParsed.FirstName;
                        contact.LastName = contactParsed.LastName;
                        contact.BirthDate = contactParsed.BirthDate;
                        contact.TelephoneNumber = contactParsed.TelephoneNumber;
                        contact.Email = contactParsed.Email;
                        contact.CivilStatus = contactParsed.CivilStatus;
                        contact.Disabled = contactParsed.Disabled;
                        _context.Entry(contact).State = EntityState.Modified;
                        response.message = "edited: done";
                        break;

                    case CONSTANT.DELETE:
                        contact = await _context.Contacts.FindAsync(contactParsed.Id);
                        contact.Disabled = !contact.Disabled;
                        _context.Entry(contact).State = EntityState.Modified;
                        response.message = "deleted: done";
                        break;

                    default:
                        response.success = false;
                        break;
                }
                if (response.success) await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            return response;
        }
    }
}
