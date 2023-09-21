using Summit.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summit.Repositories.Interfaces
{
    public interface ICustomerFNARepository
    {
        Task<CustomerFna> GetCustomerByIdAsync(string customerId, CancellationToken cancellationToken);
        Task<List<CustomerFna>> GetCustomerFNAsByCustomerIdAsync(string customerId, CancellationToken cancellationToken);
        Task<CustomerFna> CreateCustomerAsync(CustomerFna customer, CancellationToken cancellationToken);
        Task<CustomerFna> UpdateCustomerAsync(CustomerFna customer, CancellationToken cancellationToken);

    }
}
