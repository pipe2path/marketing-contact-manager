using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly CMContext _context;

        public ContactRepository(CMContext context)
        {
            _context = context;
        }    

        public async Task<IReadOnlyList<Contact>> GetContactsAsync()
        {
            return await _context.Contact.ToListAsync();
        }
    }
}