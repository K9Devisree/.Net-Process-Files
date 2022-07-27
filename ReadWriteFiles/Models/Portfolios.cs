using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace ReadWriteFiles.Models
{
    [Serializable]
    public class Portfolios
    {
        [CsvColumn(Name = "PortfolioId", FieldIndex = 1)]
        public int PortfolioId { get; set; }

        [CsvColumn(Name = "PortfolioCode", FieldIndex = 2)]
        public string? PortfolioCode { get; set; }
    }
}
