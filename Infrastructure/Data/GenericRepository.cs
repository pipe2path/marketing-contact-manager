using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        CMContext _context;
        public GenericRepository(CMContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Single Contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        
        /// <summary>
        /// All Contacts
        /// </summary>
        /// <returns></returns> <summary>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Create a new Contact 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Update an existing Contact
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
             _context.Set<T>().Attach(entity);
             _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete a Contact
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        

    }
}