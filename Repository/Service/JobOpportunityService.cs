using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Extensions;
using Repository.Interface;
using X.PagedList;

namespace Repository.Service
{
    public class JobOpportunityService : BaseService<JobOpportunity>, IJobOpportunityService
    {
        public JobOpportunityService(TrabaIoContext context) : base(context) { }

        public Task<IPagedList<JobOpportunity>> Get(int pageIndex = 1, int pageLimit = 10) =>
            Context.JobOpportunities.OrderByDescending(jo => jo.CreatedDate).ToPagedListAsync(pageIndex, pageLimit);

        public async Task<IPagedList<JobOpportunity>> Get(User user, int pageIndex = 1, int pageLimit = 10)
        {
            var result = from jo in Context.JobOpportunities
                join c in Context.Companies on jo.CompanyId equals c.Id
                join uc in Context.UserCompanies on c.Id equals uc.CompanyId
                where uc.UserId == user.Id
                select jo;

            return (await result.ToPagedListAsync(pageIndex, pageLimit));
        }

        public async Task<int> Count(User user)
        {
            var result = from jo in Context.JobOpportunities
                join c in Context.Companies on jo.CompanyId equals c.Id
                join uc in Context.UserCompanies on c.Id equals uc.CompanyId
                where uc.UserId == user.Id
                select jo;

            return (await result.CountAsync());
        }

        public Task<IPagedList<JobOpportunity>> Get(Company company, int pageIndex = 1, int pageLimit = 10) =>
            Context.JobOpportunities.Where(jo => jo.CompanyId == company.Id).ToPagedListAsync(pageIndex, pageLimit);

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