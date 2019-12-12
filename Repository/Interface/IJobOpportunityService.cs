using System.Threading.Tasks;
using Domain.Entity;
using X.PagedList;

namespace Repository.Interface
{
    public interface IJobOpportunityService
    {
        Task<IPagedList<JobOpportunity>> Get(int pageIndex = 1, int pageLimit = 10);
        Task<IPagedList<JobOpportunity>> Get(User user, int pageIndex = 1, int pageLimit = 10);
        Task<IPagedList<JobOpportunity>> Get(Company company, int pageIndex = 1, int pageLimit = 10);
        Task<JobOpportunity> Get(string companyUri, string uri);
        Task<JobOpportunity> Get(Company company, string uri);
        Task<JobOpportunity> Get(long id);
        Task Save(JobOpportunity o, User actor);
    }
}