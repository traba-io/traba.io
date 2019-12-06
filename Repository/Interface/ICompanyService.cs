using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;
using Repository.Abstract;

namespace Repository.Interface
{
    public interface ICompanyService
    {
        Task<List<Company>> Get(int pageIndex = 1, int pageLimit = 10);
        Task<List<Company>> Get(User user, int pageIndex = 1, int pageLimit = 10);
        Task<Company> Get(string uri);
        Task<Company> Get(long id);
        Task Save(Company o, User actor);
    }
}