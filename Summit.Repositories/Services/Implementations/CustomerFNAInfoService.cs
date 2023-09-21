using Summit.Models.Contracts.Responses;
using Summit.Models.Models;
using Summit.Models.Translators.Adapter;
using Summit.Repositories.Interfaces;
using Summit.Repositories.Services.Interfaces;
using SummitAppDemo.Contracts.Requests;
using SummitAppDemo.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summit.Repositories.Services.Implementations
{
    public class CustomerFNAInfoService : ICustomerFNAInfoService
    {
        private readonly ICustomerFNARepository _customerFNARepository;
        public CustomerFNAInfoService(ICustomerFNARepository customerFNARepository)
        {
            _customerFNARepository = customerFNARepository;
        }
        public async Task<CustomerFNAResponse> CreateCustomerAsync(CreateCustomerFnaReq createCustomerReq, CancellationToken cancellationToken = default)
        {
         var customerfna=   RequestTransform.toAdapterModel(createCustomerReq);
          var oldcustomerfna= await _customerFNARepository.GetCustomerByIdAsync(createCustomerReq.CustomerId, cancellationToken);
            if (oldcustomerfna != null)
            {
                oldcustomerfna.Status = false;
                oldcustomerfna.LastUpdated= DateTime.UtcNow;
                oldcustomerfna.UpdatedBy = "DEFAULT";
                _customerFNARepository.UpdateCustomerAsync(oldcustomerfna, cancellationToken);
            }
           var newCustomer= await _customerFNARepository.CreateCustomerAsync(customerfna, cancellationToken);
          var response=  ResponseTransform.fromAdapterModel(newCustomer);
            return response;
        }

        public async Task<List<CustomerFNAResponseDto>> GetCustomerFnasByCustomerId(string customerid, CancellationToken cancellationToken = default)
        {
         var fnas=  await _customerFNARepository.GetCustomerFNAsByCustomerIdAsync(customerid, cancellationToken);
        var responses=    ResponseTransform.fromAdapterModel(fnas);
            return responses;
        }
    }
}
