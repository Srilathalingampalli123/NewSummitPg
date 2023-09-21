using Newtonsoft.Json;
using Summit.Models.Contracts.Responses;
using Summit.Models.Models;
using SummitAppDemo.Contracts.Requests;
using SummitAppDemo.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Summit.Models.Translators.Adapter
{
    public class ResponseTransform
    {
        public static CustomerFNAResponse? fromAdapterModel(CustomerFna customer)
        {
            return customer == null ? null : new CustomerFNAResponse()
            {
                CustFnaId = customer.CustFnaId,
                CustomerId = customer.CustomerId,
                FnaId = customer.FnaId,
                Input=JsonConvert.DeserializeObject<Dictionary<string,string>>(customer.Input),
                Output = JsonConvert.DeserializeObject<List<OutPutValue>>(customer.Output),
                Addedby=customer.Addedby,
                DateAdded=customer.DateAdded,
                Status=customer.Status,

            };
        }

        public static List<CustomerFNAResponseDto>? fromAdapterModel(List<CustomerFna> customerfnas)
        {
            var customers = new List<CustomerFNAResponseDto>();
            foreach (var customer in customerfnas)
            {
                customers.Add(new CustomerFNAResponseDto()
                {
                    FnaId=customer.FnaId,
                    Input=JsonConvert.DeserializeObject<Dictionary<string,string>>(customer.Input),
                    Output=JsonConvert.DeserializeObject<List<OutPutValue>>(customer.Output),
                    Score=customer.Score,


                });
            }
            return customers;
          

        }
    }
}
