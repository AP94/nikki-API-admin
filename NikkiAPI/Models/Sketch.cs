using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NikkiApi.Models
{
    public enum SketchSource {
        None,
        Chest,
        Quest,
        Event,
        StyleChallenge,
        Heart,
        Kilo,
        Courses,
        Quiz,
        Expeditions,
        Sovereign,
        Daily
    }

    public enum SketchCategory {
        None,
        MiracleOutfits,
        AbilityOutfits,
        StylishOutfits,
        RarePieces,
        WhimFragrance,
        MomosCloak
    }

    public class Sketch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public int Quality { get; set; } = 1!;
        public int ThreadCost { get; set; } = 0!;
        public int BlingsCost { get; set; } = 0!;
        public SketchSource SketchSource { get; set; } = 0!;
        public SketchCategory SketchCategory { get; set; } = 0!;
        public (string, int)[] MaterialsCost { get; set; } = []!;
    }
}