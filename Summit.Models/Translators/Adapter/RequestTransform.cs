using Summit.Models.Models;
using SummitAppDemo.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Summit.Models.Translators.Adapter
{
    public class RequestTransform
    {
        public static CustomerFna? toAdapterModel(CreateCustomerFnaReq createCustomerReq)
        {
            return createCustomerReq == null ? null : new CustomerFna()
            {
                CustFnaId = "customer_Fna_" + Guid.NewGuid().ToString(),
                CustomerId = createCustomerReq.CustomerId,
                Addedby = "default",
                FnaId = createCustomerReq.FnaId,
                Input = JsonSerializer.Serialize(createCustomerReq.InputJson),
                Output = JsonSerializer.Serialize(createCustomerReq.OutputJson),
                Score = createCustomerReq.FNAScore,
                Status = true,
                DateAdded =DateTime.UtcNow
            };
        }
    }
}
