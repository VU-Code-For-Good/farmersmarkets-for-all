namespace FarmersMarketApi.Domain.Models
{
    public class FarmersMarket
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public OperationTimes OperationTimes { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
