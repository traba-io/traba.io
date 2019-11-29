using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Interface;

namespace Repository.Service
{
    public class JobOpportunityService : BaseService<JobOpportunity>, IJobOpportunityService
    {
        public JobOpportunityService(TrabaIoContext context) : base(context) { }

        public Task<List<JobOpportunity>> Get(int pageIndex = 1, int pageLimit = 10) =>
            Context.JobOpportunities.OrderByDescending(jo => jo.CreatedDate).Skip(pageLimit*(pageIndex - 1)).Take(pageLimit).ToListAsync();

        public Task<List<JobOpportunity>> Get(Company company, int pageIndex = 1, int pageLimit = 10) =>
            Context.JobOpportunities.Where(jo => jo.CompanyId == company.Id).Skip(pageLimit*pageIndex-1).Take(pageLimit).ToListAsync();

        public Task<JobOpportunity> Get(string companyUri, string uri) =>
            Context.JobOpportunities.FirstOrDefaultAsync(jo => jo.Namespace == uri && jo.Company.Uri == companyUri);

        public Task<JobOpportunity> Get(Company company, string uri) =>
            Context.JobOpportunities.FirstOrDefaultAsync(jo => jo.Namespace == uri && jo.CompanyId == company.Id);

        public Task<JobOpportunity> Get(long id) => 
            Context.JobOpportunities.FirstOrDefaultAsync(jo => jo.Id == id);
    }
}