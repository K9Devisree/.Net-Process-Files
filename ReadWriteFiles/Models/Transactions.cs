using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace ReadWriteFiles.Models
{
    [Serializable]
    public class Transactions
    {
        [CsvColumn(Name = "SecurityId", FieldIndex = 1)]
        public int SecurityId { get; set; }

        [CsvColumn(Name = "PortfolioId", FieldIndex = 2)]
        public int PortfolioId { get; set; }

        [CsvColumn(Name = "Nominal", FieldIndex = 3)]
        public decimal Nominal { get; set; }

        [CsvColumn(Name = "OMS", FieldIndex = 4)]
        public string? OMS { get; set; }

        [CsvColumn(Name = "TransactionType", FieldIndex = 5)]
        public string? TransactionType { get; set; }
    }
}
