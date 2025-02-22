using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NikkiApi.Models
{
    public class Material
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("Type")]
        [JsonPropertyName("Type")]
        public MaterialType MaterialType { get; set; } = 0!;

        public int Quality { get; set; } = 0!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string SourceId { get; set; } = null!;
        
        public bool IsEssence { get; set; } = false!;
        public BedrockCrystalType CrystalType { get; set; } = 0!;
    }

    public enum MaterialType {
        Generic,
        Harvestable,
        BedrockCrystal
    }

    public enum BedrockCrystalType {
        None,
        Command,
        Energy,
        Hurt,
        Plummet,
        Tumble
    }
}