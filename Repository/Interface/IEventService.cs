using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IEventService
    {
        Task<List<Event>> Get(int pageIndex = 1, int pageLimit = 10);
        Task<List<Event>> Get(User user, int pageIndex = 1, int pageLimit = 10);
        Task<Event> Get(string uri);
        Task<Event> Get(long id);
        Task Save(Event o, User actor);
    }
}