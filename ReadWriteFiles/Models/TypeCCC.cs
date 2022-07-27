using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteFiles.Models
{
    [Serializable]
    public class TypeCCC
    {
        public string? PortfolioCode { get; set; }
        public string? Ticker { get; set; }
        public decimal Nominal { get; set; }
        public string? TransactionType { get; set; }

    }
}
