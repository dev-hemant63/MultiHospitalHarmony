namespace MultiHospitalHarmony.Models
{
    public class Result
    {
        public int transactionId { get; set; }
        public string url { get; set; }
        public string intentString { get; set; }
        public string displayName { get; set; }
        public string requestedId { get; set; }
    }

    public class TxnRes
    {
        public Result result { get; set; }
        public int statusCode { get; set; }
        public string responseText { get; set; }
    }
    public class StatusRes
    {
        public int statusCode { get; set; }
        public string responseText { get; set; }
        public string utr { get; set; }
        public string requestedId { get; set; }
        public int tid { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public string qrid { get; set; }
        public string displayName { get; set; }
        public object url { get; set; }
        public string entryOn { get; set; }
        public string webhook { get; set; }
        public string serverhook { get; set; }
    }


}
