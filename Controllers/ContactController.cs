using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trilha_net_api.Context;
using trilha_net_api.Entities;

namespace trilha_net_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {   
        private readonly AgendaContext _context;

        public ContactController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetContactsById), new { id = contact.Id}, contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactsById(int id)
        {
            var contact = _context.Contacts.Find(id);
            
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet("GetByName")]
        public IActionResult GetContactsByName(string name)
        {
            var contacts = _context.Contacts.Where(x => x.Name.Contains(name));

            return Ok(contacts);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var tableContact = _context.Contacts.Find(id);

            if (tableContact == null)
                return NotFound();

            tableContact.Name = contact.Name;
            tableContact.Telefone = contact.Telefone;
            tableContact.Active = contact.Active;

            _context.Contacts.Update(tableContact);
            _context.SaveChanges();

            return Ok(tableContact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return NotFound();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return NoContent();
        }
    }
}