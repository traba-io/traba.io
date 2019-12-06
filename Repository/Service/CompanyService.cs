using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Extensions;
using Repository.Interface;

namespace Repository.Service
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(TrabaIoContext context) : base(context) { }
        public Task<List<Company>> Get(int pageIndex = 1, int pageLimit = 10) => Context.Companies.ToListAsync();

        public Task<List<Company>> Get(User user, int pageIndex = 1, int pageLimit = 10) => Context.Companies
            .Where(c => c.Users.Any(u => u.UserId == user.Id)).OrderByDescending(jo => jo.CreatedDate)
            .Skip(pageLimit * (pageIndex - 1)).Take(pageLimit).ToListAsync();
        
        public Task<Company> Get(string uri) => Context.Companies.FirstOrDefaultAsync(c => c.Namespace == uri);
        public Task<Company> Get(long id) => Context.Companies.FirstOrDefaultAsync(c => c.Id == id);

        public Task Save(Company o, User actor)
        {
            if (o.IsNew)
            {
                var userCompany = new UserCompany() {UserId = actor.Id, Owner = true};
                o.Users.Add(userCompany);
            }
            
            o.Namespace = o.Name.ToUri();
            
            return base.Save(o);
        }
    }
}