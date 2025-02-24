using NikkiApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace NikkiApi.Services
{
    public class MaterialSourcesService
    {
        private readonly IMongoCollection<MaterialSource> _materialSources;

        public MaterialSourcesService(IMaterialSourcesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _materialSources = database.GetCollection<MaterialSource>(settings.MaterialSourcesCollectionName);
        }

        public List<MaterialSource> Get() => _materialSources.Find(materialSource => true).ToList();

        public MaterialSource Get(string id) => _materialSources.Find(materialSource => materialSource.Id == id).FirstOrDefault();

        public MaterialSource Create(MaterialSource materialSource)
        {
            _materialSources.InsertOne(materialSource);
            return materialSource;
        }

        public List<MaterialSource> Create(List<MaterialSource> materialSources) {
            _materialSources.InsertMany(materialSources);
            return materialSources;
        }

        public void Update(string id, MaterialSource updatedMaterialSource) => _materialSources.ReplaceOne(materialSource => materialSource.Id == id, updatedMaterialSource);

        public void Delete(MaterialSource materialSourceToDelete) => _materialSources.DeleteOne(materialSource => materialSource.Id == materialSourceToDelete.Id);

        public void Delete(string id) => _materialSources.DeleteOne(materialSource => materialSource.Id == id);
        
        public async Task<List<MaterialSource>> GetAsync() => await _materialSources.Find(materialSource => true).ToListAsync();

        public async Task<MaterialSource> GetAsync(string id) => await _materialSources.Find(materialSource => materialSource.Id == id).FirstOrDefaultAsync();

        public async void UpdateAsync(string id, MaterialSource updatedMaterialSource) => await _materialSources.ReplaceOneAsync(materialSource => materialSource.Id == id, updatedMaterialSource);

        public async void DeleteAsync(MaterialSource materialSourceToDelete) => await _materialSources.DeleteOneAsync(materialSource => materialSource.Id == materialSourceToDelete.Id);

        public async void DeleteAsync(string id) => await _materialSources.DeleteOneAsync(materialSource => materialSource.Id == id);
    }
}