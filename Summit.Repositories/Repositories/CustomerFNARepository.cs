using Microsoft.EntityFrameworkCore;
using Summit.Models.Models;
using Summit.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summit.Repositories.Repositories
{
    public class CustomerFNARepository : GenericRepository<CustomerFna>, ICustomerFNARepository
    {
        public CustomerFNARepository(DbContext context, bool isMoc = false) : base(context, isMoc)
        {
        }

        public async Task<CustomerFna> CreateCustomerAsync(CustomerFna customer, CancellationToken cancellationToken)
        {
            var customerresponse = await dbset.AddAsync(customer);
            await dbContext.SaveChangesAsync(cancellationToken);
            return customerresponse.Entity;
        }

        public async Task<CustomerFna> GetCustomerByIdAsync(string customerId, CancellationToken cancellationToken)
        {
            var res = await dbset.Where(x => x.CustomerId == customerId && x.Status == true).FirstOrDefaultAsync();
            return res;
        }

        public Task<List<CustomerFna>> GetCustomerFNAsByCustomerIdAsync(string customerId, CancellationToken cancellationToken)
        {
           return dbset.Where(x=>x.CustomerId==customerId).ToListAsync();
        }

        public async Task<CustomerFna> UpdateCustomerAsync(CustomerFna customer, CancellationToken cancellationToken)
        {
           return await UpdateAsync(customer);
        }
    }
}
