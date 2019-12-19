using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;
using Repository.Abstract;
using Repository.Interface;

namespace Repository.Service
{
    public class EventService : BaseService<Event>, IEventService
    {
        public EventService(TrabaIoContext context) : base(context)
        {
        }

        public Task<List<Event>> Get(int pageIndex = 1, int pageLimit = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Event>> Get(User user, int pageIndex = 1, int pageLimit = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Count(User user) => throw new System.NotImplementedException();

        public Task<Event> Get(string uri)
        {
            throw new System.NotImplementedException();
        }

        public Task<Event> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(Event o, User actor)
        {
            throw new System.NotImplementedException();
        }
    }
}