using Summit.Models.Contracts.Responses;
using SummitAppDemo.Contracts.Requests;
using SummitAppDemo.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summit.Repositories.Services.Interfaces
{
    public interface ICustomerFNAInfoService
    {
        Task<CustomerFNAResponse> CreateCustomerAsync(CreateCustomerFnaReq createCustomerReq, CancellationToken cancellationToken = default);
        //Task<CreateCustomerFnaReq> GetCustomerAsync(string id, CancellationToken cancellationToken = default);
        Task<List<CustomerFNAResponseDto>> GetCustomerFnasByCustomerId(string customerid, CancellationToken cancellationToken = default);
    }
}
