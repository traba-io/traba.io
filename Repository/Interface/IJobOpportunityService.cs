using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IJobOpportunityService
    {
        Task<List<JobOpportunity>> Get(int pageIndex = 1, int pageLimit = 10);
        Task<List<JobOpportunity>> Get(User user, int pageIndex = 1, int pageLimit = 10);
        Task<List<JobOpportunity>> Get(Company company, int pageIndex = 1, int pageLimit = 10);
        Task<JobOpportunity> Get(string companyUri, string uri);
        Task<JobOpportunity> Get(Company company, string uri);
        Task<JobOpportunity> Get(long id);
        Task Save(JobOpportunity o, User actor);
    }
}