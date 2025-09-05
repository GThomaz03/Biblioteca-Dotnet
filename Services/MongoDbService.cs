using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Livro> _livrosCollection;

        public MongoDbService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _livrosCollection = database.GetCollection<Livro>("Livros");
        try
        {
            database.ListCollections(); 
            Console.WriteLine("Conexão com MongoDB Atlas OK!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao conectar MongoDB Atlas: " + ex.Message);
        }
        }

        public async Task<List<Livro>> GetAsync() =>
            await _livrosCollection.Find(_ => true).ToListAsync();

        public async Task<Livro> GetAsync(string id) =>
            await _livrosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Livro newLivro) =>
            await _livrosCollection.InsertOneAsync(newLivro);

        public async Task UpdateAsync(string id, Livro updatedLivro) =>
            await _livrosCollection.ReplaceOneAsync(x => x.Id == id, updatedLivro);

        public async Task RemoveAsync(string id) =>
            await _livrosCollection.DeleteOneAsync(x => x.Id == id);
    }
}