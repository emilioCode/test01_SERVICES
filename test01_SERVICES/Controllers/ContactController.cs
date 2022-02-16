using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test01_SERVICES.Models.Data;
using test01_SERVICES.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
