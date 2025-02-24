using NikkiApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace NikkiApi.Services
{
    public class MaterialsService
    {
        private readonly IMongoCollection<Material> _materials;

        public MaterialsService(IMaterialsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _materials = database.GetCollection<Material>(settings.MaterialsCollectionName);
        }

        public List<Material> Get() => _materials.Find(material => true).ToList();

        public Material Get(string id) => _materials.Find(material => material.Id == id).FirstOrDefault();

        public Material Create(Material material)
        {
            _materials.InsertOne(material);
            return material;
        }
        
        public List<Material> Create(List<Material> materials) {
            _materials.InsertMany(materials);
            return materials;
        }

        public void Update(string id, Material updatedMaterial) => _materials.ReplaceOne(material => material.Id == id, updatedMaterial);

        public void Delete(Material materialToDelete) => _materials.DeleteOne(material => material.Id == materialToDelete.Id);

        public void Delete(string id) => _materials.DeleteOne(material => material.Id == id);

        
        public async Task<List<Material>> GetAsync() => await _materials.Find(material => true).ToListAsync();

        public async Task<Material> GetAsync(string id) => await _materials.Find(material => material.Id == id).FirstOrDefaultAsync();

        public async void UpdateAsync(string id, Material updatedMaterial) => await _materials.ReplaceOneAsync(material => material.Id == id, updatedMaterial);

        public async void DeleteAsync(Material materialToDelete) => await _materials.DeleteOneAsync(material => material.Id == materialToDelete.Id);

        public async void DeleteAsync(string id) => await _materials.DeleteOneAsync(material => material.Id == id);
    }
}