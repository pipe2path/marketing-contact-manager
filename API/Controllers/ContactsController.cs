using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

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
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactRepo.GetByIdAsync(id);
            if (contact == null) return NotFound();
            return contact;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            _contactRepo.Add(contact);

            if (await _contactRepo.SaveAllAsync())
            {
                return CreatedAtAction("GetContact", new {id = contact.Id}, contact);
            }

            return BadRequest("Problem creating contact");
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateContact(int id, Contact contact)
        {
            if (contact.Id != id || contact == null)
                return BadRequest("Cannot update this product");

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
            if (contact == null) return NotFound();

            _contactRepo.Remove(contact);
            if (await _contactRepo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem deleting this product");
        }
    }
}