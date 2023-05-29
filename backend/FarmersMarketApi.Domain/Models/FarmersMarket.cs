namespace FarmersMarketApi.Domain.Models
{
    public class FarmersMarket
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public OperationTimes OperationTimes { get; set; }
        //TDO we should probably make this a string
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
