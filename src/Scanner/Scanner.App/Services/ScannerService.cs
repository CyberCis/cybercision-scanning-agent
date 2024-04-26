using Scanner.App.Models;
using Scanner.App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.App.Services
{
    public class ScannerService
    {
        private readonly ScannerRepository scannerRepository;
        private static readonly string[] FileLabels = new[]
        {
            "Cool", "Mild", "Risky", "Low", "Medium", "High", "Warning"
        };

        public ScannerService()
        {
            scannerRepository = new ScannerRepository();
        }

        public async Task Run()
        {
            var scanResult = Scan();
            await scannerRepository.CreateAsync(new ScannerModel
            {
                Id = Guid.NewGuid().ToString("N"),
                ComId = "testCompany",
                Result = scanResult
            });

            var dbres = await scannerRepository.GetAsync("testCompany");
        }

        private FileScanResponse Scan()
        {
            var list = new List<FileScanDetails>();
            var scanFolder = @"C:\projects\examples\mypersonalwebsite";
            var d = new DirectoryInfo(scanFolder); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories); //Getting Text files

            foreach (FileInfo file in Files)
            {
                var fd = new FileScanDetails
                {
                    Name = file.Name,
                    Labels = new List<string>()
                };

                var rng = new Random();
                for (var i = 0; i < rng.Next(FileLabels.Length); i++)
                {
                    var label = FileLabels[rng.Next(FileLabels.Length)];
                    if (!fd.Labels.Contains(label))
                    {
                        fd.Labels.Add(label);
                    }
                }

                list.Add(fd);
            }

            return new FileScanResponse { ScanResult = list, ScanFolder = scanFolder };
        }
    }
}
