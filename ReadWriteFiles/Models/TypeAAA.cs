﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteFiles.Models
{
    [Serializable]
    public class TypeAAA
    {
        public string? ISIN { get; set; }
        public string? PortfolioCode { get; set; }
        public decimal Nominal { get; set; }
        public string? TransactionType { get; set; }
    }
}
