﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarketApi.Domain.Models
{
    public class FarmersMarket
    { public Guid Id { get; set; }
        public string Name { get; set; }
        public OperationTimes OperationTimes { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
