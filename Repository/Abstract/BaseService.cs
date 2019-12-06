using System;
using System.Threading.Tasks;
using Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Repository.Abstract
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        protected readonly TrabaIoContext Context;
        
        public BaseService(TrabaIoContext context)
        {
            Context = context;
        }
        
        public virtual async Task Save(T o)
        {
            if (o.IsNew)
            {
                Context.Attach(o);
                o.CreatedDate = DateTime.Now;
            }
            else
            {
                o.UpdatedDate = DateTime.Now;
                var entry = await Context.AddAsync(o);
                entry.State = EntityState.Modified;
                entry.Property(e => e.CreatedDate).IsModified = false;
            }

            await Context.SaveChangesAsync();
        }
    }
}