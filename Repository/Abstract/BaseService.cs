using System.Threading.Tasks;
using Domain.Abstract;

namespace Repository.Abstract
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        protected readonly TrabaIoContext Context;
        
        public BaseService(TrabaIoContext context)
        {
            Context = context;
        }
        
        public async Task Save(T o)
        {
            if (o.IsNew)
            {
                Context.Attach(o);
            }
            else
            {
                await Context.AddAsync(o);
            }

            await Context.SaveChangesAsync();
        }
    }
}