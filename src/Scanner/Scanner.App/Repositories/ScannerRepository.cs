using MongoDB.Driver;
using Scanner.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.App.Repositories
{
    public class ScannerRepository
    {
        private readonly IMongoCollection<ScannerModel> _collection;
        private readonly MongoClient _client;

        public ScannerRepository()
        {
            _client = new MongoClient("mongodb+srv://cybercision:matred-vuJji0-tukhez@cybercision-cluster.mongocluster.cosmos.azure.com/?tls=true&authMechanism=SCRAM-SHA-256&retrywrites=false&maxIdleTimeMS=120000");
            var mongoDatabase = _client.GetDatabase("ScanResultsDB");

            _collection = mongoDatabase.GetCollection<ScannerModel>("Scans");
        }

        public async Task<List<ScannerModel>> GetAsync(string comId) =>
            await _collection.Find(x => x.ComId == comId).ToListAsync();

        public async Task CreateAsync(ScannerModel newTenant) =>
            await _collection.InsertOneAsync(newTenant);

        public async Task UpdateAsync(string id, ScannerModel updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
