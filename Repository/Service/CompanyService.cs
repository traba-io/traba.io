using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Interface;

namespace Repository.Service
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(TrabaIoContext context) : base(context) { }

        public Task<List<Company>> Get(int pageIndex = 1, int pageLimit = 10) => Context.Companies.ToListAsync();

        public Task<Company> Get(string uri) => Context.Companies.FirstOrDefaultAsync(c => c.Namespace == uri);

        public Task<Company> Get(long id) => Context.Companies.FirstOrDefaultAsync(c => c.Id == id);
    }
}