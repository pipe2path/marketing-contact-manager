using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using API.Errors;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {   
        private readonly IGenericRepository<Contact> _contactRepo;
        public ContactsController(IGenericRepository<Contact> contactRepo)
        {
            _contactRepo = contactRepo;                
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Contact>>> GetContacts()
        {
            var contacts = await _contactRepo.ListAllAsync();
            return Ok(contacts);
            
            // example to show unhandled exception handled by exception middleware
            //throw new Exception("This is a test exception");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactRepo.GetByIdAsync(id);
            if (contact == null) return NotFound("Contact not found");
            return contact;
        }

        [ValidateModel]
        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            if (contact == null) 
                return BadRequest("No contact data received");

            if (!validEmail(contact.Email))
                return BadRequest("Email address is not valid");

            _contactRepo.Add(contact);

            if (await _contactRepo.SaveAllAsync())
            {
                return CreatedAtAction("GetContact", new {id = contact.Id}, contact);
            }
            return BadRequest("Problem creating contact");
        }

        [ValidateModel]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateContact(int id, Contact contact)
        {
            if (contact.Id != id)
                return BadRequest("Contact not found, cannot update");

            if (!validEmail(contact.Email))
                return BadRequest("Email address is not valid");
                
            _contactRepo.Update(contact);
            if (await _contactRepo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem updating this product");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var contact = await _contactRepo.GetByIdAsync(id);
            if (contact == null) return NotFound("Cannot find contact to delete");

            _contactRepo.Remove(contact);
            if (await _contactRepo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem deleting this product");
        }

        private bool validEmail(string email)
        {
            var regex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
            if (regex.IsMatch(email))
                return true;
            return false;
        }
    }
}