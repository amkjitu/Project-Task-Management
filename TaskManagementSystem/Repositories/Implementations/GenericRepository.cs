using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagementSystem.Data;
using TaskManagementSystem.Repositories.Interfaces;

namespace TaskManagementSystem.Repositories.Implementations
    {
    public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
            {
            _context = context;
            _dbSet = _context.Set<T>();
            }

        public async Task<T> GetByIdAsync(int id)
            {
            return await _dbSet.FindAsync(id);
            }

        public async Task<IEnumerable<T>> GetAllAsync()
            {
            return await _dbSet.ToListAsync();
            }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            {
            return await _dbSet.FirstOrDefaultAsync(predicate);
            }

        ////for readonly
        //public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) =>
        //    await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            {
            return await _dbSet.Where(predicate).ToListAsync();
            }

        public async Task AddAsync(T entity)
            {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            }

        public async Task UpdateAsync(T entity)
            {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            }

        public async Task DeleteAsync(T entity)
            {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            }
        }
    }
