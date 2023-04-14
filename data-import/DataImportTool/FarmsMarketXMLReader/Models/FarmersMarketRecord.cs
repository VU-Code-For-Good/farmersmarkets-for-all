using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmsMarketXMLReader.Models
{
    public class FarmersMarketRecord
    {
        public string StoreName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AddlAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CountyName { get; set; }
    }
}
