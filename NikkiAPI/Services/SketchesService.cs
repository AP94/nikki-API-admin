using NikkiApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace NikkiApi.Services
{
    public class SketchesService
    {
        private readonly IMongoCollection<Sketch> _sketches;

        public SketchesService(ISketchesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sketches = database.GetCollection<Sketch>(settings.SketchesCollectionName);
        }

        public List<Sketch> Get() => _sketches.Find(sketch => true).ToList();

        public Sketch Get(string id) => _sketches.Find(sketch => sketch.Id == id).FirstOrDefault();

        public Sketch Create(Sketch sketch)
        {
            _sketches.InsertOne(sketch);
            return sketch;
        }

        public List<Sketch> Create(List<Sketch> sketches) {
            _sketches.InsertMany(sketches);
            return sketches;
        }

        public void Update(string id, Sketch updatedSketch) => _sketches.ReplaceOne(sketch => sketch.Id == id, updatedSketch);

        public void Delete(Sketch sketchToDelete) => _sketches.DeleteOne(sketch => sketch.Id == sketchToDelete.Id);

        public void Delete(string id) => _sketches.DeleteOne(sketch => sketch.Id == id);
    }
}