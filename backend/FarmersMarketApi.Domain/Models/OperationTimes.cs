using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FarmersMarketApi.Domain.Models
{
    public class OperationTimes
    {
        //TODO this model is funky
        public string OperatingHours { get; set; }
        public string OperatingDays { get; set; }
        public string OperatingMonths { get; set; }
    }
}
