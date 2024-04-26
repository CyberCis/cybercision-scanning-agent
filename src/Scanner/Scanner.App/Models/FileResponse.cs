using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.App.Models
{
    public class FileScanDetails
    {
        public string Name { get; set; }

        public List<string> Labels { get; set; }
    }

    public class FileScanResponse
    {
        public DateTime ScanDateTime => DateTime.Now;

        public List<FileScanDetails> ScanResult { get; set; }

        public string ScanFolder { get; set; }
    }
}
