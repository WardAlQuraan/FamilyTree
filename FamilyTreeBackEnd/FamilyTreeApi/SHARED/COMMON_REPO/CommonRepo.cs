using ENTITIES.BASE_ENTITY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.COMMON_REPO
{
    public class CommonRepo<T> : ICommonRepo<T> where T:BaseEntity
    {
        private readonly DbContext context;
        private DbSet<T> entities;

        public CommonRepo(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var items = await entities.Where(x=>x.IsDeleted==0).ToListAsync();
            return items;

        }
        public virtual async Task<bool> CheckExist(int id) 
        {
            var item = await GetAsync(id);
            if (item == null)
                return false;
            return true;
        }
        public virtual async Task<T> GetAsync(int id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id && s.IsDeleted==0);
        }
        public virtual async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreationBy = "Admin";
            entity.CreationDate = DateTime.Now;
            entity.IsDeleted = 0;
            entities.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry<T>(entity).State = EntityState.Modified;
            entity.ModificationBy = "Admin";
            entity.ModificationDate = DateTime.Now;
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.IsDeleted = 1;
            await UpdateAsync(entity);
            return true;
        }
    }
}
