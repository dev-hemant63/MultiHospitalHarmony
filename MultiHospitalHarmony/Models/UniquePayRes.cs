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
        public statusData result { get; set; }
    }
    public class statusData
    {
        public string status { get; set; }
        public string requestedId { get; set; }
        public double amount { get; set; }
        public string utr { get; set; }
        public int tid { get; set; }
        public string transactionInitiatedAt { get; set; }
    }

}
