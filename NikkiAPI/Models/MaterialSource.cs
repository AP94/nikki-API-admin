using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NikkiApi.Models
{
    public class MaterialSource {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null!;
        public HarvestType HarvestedBy { get; set; } = 0!;
        public Region[] Regions { get; set; } = []!;
        public Location[] Locations { get; set; } = []!;
    }
    
    public enum HarvestType {
        None,
        Collecting,
        AnimalGrooming,
        BugCatching,
        Fishing
    }

    public enum Location {
        None,
        Quest,
        Combat,
        WarpSpire,
        Florawish,
        BreezyMeadow,
        Stoneville,
        AbandonedDistrict,
        WishingWoods,
        MemorialMountains,
        FireworkIsles
    }

    public enum Region {
        None,
        Wishfield
    }
}