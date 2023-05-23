using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Helpers.Services;
using WebApp.Models;
using WebApp.Models.Identity;
using WebApp.ViewModels.AdminView;

namespace WebApp.Helpers.Repositories.User
{
    public class Repo<TEntity> where TEntity : class
    {
        private readonly IdentityContext _context;

        public Repo(IdentityContext context)
        {
            _context = context;
        }

        // ============================================ ADD ================================ //
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // ============================================ GET ONE ================================ //
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

                return entity!;
            }
            catch { return null!; }
        }


        // ============================================ GET ALL  ================================ //
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var users = await _context.Set<TEntity>().Where(expression).ToListAsync();
                return users!;
            }
            catch { return null!; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var users = await _context.Set<TEntity>().ToListAsync();
                return users!;
            }
            catch { return null!; }
        }




        // ============================================ UPDATE ================================ //
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch { return null!; }
        }

        // ============================================ DELETE ================================ //
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; };


        }
    }
}
