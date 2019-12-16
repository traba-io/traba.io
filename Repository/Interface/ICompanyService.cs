using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;
using Repository.Abstract;
using X.PagedList;

namespace Repository.Interface
{
    public interface ICompanyService
    {
        Task<IPagedList<Company>> Get(int pageIndex = 1, int pageLimit = 10);
        Task<IPagedList<Company>> Get(User user, int pageIndex = 1, int pageLimit = 10);
        Task<int> Count(User user);
        Task<Company> Get(string uri);
        Task<Company> Get(long id);
        Task Save(Company o, User actor);
    }
}