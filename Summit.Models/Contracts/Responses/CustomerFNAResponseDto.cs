using SummitAppDemo.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summit.Models.Contracts.Responses
{
    public class CustomerFNAResponseDto
    {
        public int FnaId { get; set; }

        public Dictionary<string, string> Input { get; set; } = null!;

        public List<OutPutValue> Output { get; set; } = null!;

        public int? Score { get; set; }
    }
}
