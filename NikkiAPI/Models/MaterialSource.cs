using System.Security.Cryptography;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NikkiApi.Models
{
    public class MaterialSource {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null!;

        public HarvestType? HarvestedBy { get; set; } = 0!;

        public Region[] Regions { get; set; } = []!;
        
        public Location[] Locations { get; set; } = []!;

        public MaterialSource() {
            Id = RandomNumberGenerator.GetHexString(24);
        }
    }

    public enum HarvestType {
        None,
        Collecting,
        AnimalGrooming,
        BugCatching,
        Fishing,
        Combat
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