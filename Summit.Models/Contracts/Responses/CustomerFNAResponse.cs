using SummitAppDemo.Contracts.Requests;

namespace SummitAppDemo.Contracts.Responses
{
    public class CustomerFNAResponse
    {
        public string CustFnaId { get; set; } = null!;

        public string CustomerId { get; set; } = null!;

        public int FnaId { get; set; }

        public Dictionary<string,string> Input { get; set; } = null!;

        public List<OutPutValue> Output { get; set; } = null!;

        public int? Score { get; set; }

        public bool? Status { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? LastUpdated { get; set; }

        public string? UpdatedBy { get; set; }

        public string? Addedby { get; set; }


    }
}
