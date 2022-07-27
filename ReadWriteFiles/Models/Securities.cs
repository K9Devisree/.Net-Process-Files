using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace ReadWriteFiles.Models
{
    [Serializable]
    public class Securities
    {
        [CsvColumn(Name = "SecurityId", FieldIndex = 1)]
        public int SecurityId { get; set; }

        [CsvColumn(Name = "ISIN", FieldIndex = 2)]
        public string? ISIN { get; set; }

        [CsvColumn(Name = "Ticker", FieldIndex = 3)]
        public string? Ticker { get; set; }

        [CsvColumn(Name = "CUSIP", FieldIndex = 4)]
        public string? CUSIP { get; set; }

    }
}
