using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Repository.Abstract;
using Repository.Extensions;
using Repository.Interface;

namespace Repository.Service
{
    public class JobOpportunityService : BaseService<JobOpportunity>, IJobOpportunityService
    {
        public JobOpportunityService(TrabaIoContext context) : base(context) { }

        public Task<List<JobOpportunity>> Get(int pageIndex = 1, int pageLimit = 10) =>
            Context.JobOpportunities.OrderByDescending(jo => jo.CreatedDate).Skip(pageLimit*(pageIndex - 1)).Take(pageLimit).ToListAsync();

        public async Task<List<JobOpportunity>> Get(User user, int pageIndex = 1, int pageLimit = 10)
        {
            var result = from jo in Context.JobOpportunities
                join c in Context.Companies on jo.CompanyId equals c.Id
                join uc in Context.UserCompanies on c.Id equals uc.CompanyId
                where uc.UserId == user.Id
                select jo;

            return (await result.ToListAsync());
        }

        public Task<List<JobOpportunity>> Get(Company company, int pageIndex = 1, int pageLimit = 10) =>
            Context.JobOpportunities.Where(jo => jo.CompanyId == company.Id).Skip(pageLimit*pageIndex-1).Take(pageLimit).ToListAsync();

        public Task<JobOpportunity> Get(string companyUri, string uri) =>
            Context.JobOpportunities.FirstOrDefaultAsync(jo => jo.Uri == uri && jo.Company.Namespace == companyUri);

        public Task<JobOpportunity> Get(Company company, string uri) =>
            Context.JobOpportunities.FirstOrDefaultAsync(jo => jo.Uri == uri && jo.CompanyId == company.Id);

        public Task<JobOpportunity> Get(long id) => 
            Context.JobOpportunities.FirstOrDefaultAsync(jo => jo.Id == id);

        public Task Save(JobOpportunity o, User actor)
        {
            o.UserId = actor.Id;
            o.Uri = o.Title.ToUri();
            return base.Save(o);
        }
    }
}