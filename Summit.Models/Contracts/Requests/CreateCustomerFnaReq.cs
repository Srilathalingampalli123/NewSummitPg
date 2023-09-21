namespace SummitAppDemo.Contracts.Requests
{
    public class CreateCustomerFnaReq
    {
        public string CustomerId { get; set; }
        public int FnaId { get; set; }
        public Dictionary<string,string> InputJson { get; set; }
        public List<OutPutValue> OutputJson { get; set; }
        public int FNAScore { get; set; }
        public int CustFNAScore { get; set; }
        public int CustFNAComplPercent { get; set; }
    }

    public class OutPutValue
    {
        public int Score { get; set;}
        public int IdealGap { get; set;}
    }
}
