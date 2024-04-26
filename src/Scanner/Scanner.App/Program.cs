using Scanner.App.Services;

namespace Scanner.App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var repo = new ScannerService();
            await repo.Run();
            Console.WriteLine("Hello, World!");
        }
    }
}
