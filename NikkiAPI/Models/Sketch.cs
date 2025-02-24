using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace NikkiApi.Models
{
    public enum SketchSource {
        None,
        Chest,
        Quest,
        Event,
        StyleChallenge,
        HeartOfInfinity,
        Kilo,
        Courses,
        Quiz,
        Expeditions
    }

    public enum SketchCategory {
        MiracleOutfits,
        AbilityOutfits,
        StylishOutfits,
        RarePieces,
        WhimFragrance,
        MomosCloak
    }

    public enum WardrobeCategory {
        Outfits,
        Hair,
        Dresses,
        Outerwear,
        Tops,
        Bottoms,
        Socks,
        Shoes,
        HairAccessories,
        Headwear,
        Earrings,
        Neckwear,
        Bracelets,
        Chokers,
        Gloves,
        FaceDecorations,
        ChestAccessories,
        Pendants,
        Backpieces,
        Rings,
        ArmDecorations,
        Handhelds,
        BaseMakeup,
        Eyebrows,
        Eyelashes,
        ContactLenses,
        Lips
    }

    public enum ClothingStyle {
        Elegant,
        Sweet,
        Cool,
        Fresh,
        Sexy
    }

    public enum Label {
        Warm,
        Summer,
        Home,
        Formal,
        Simple,
        Fantasy,
        Intellectual,
        Adventure,
        Romance,
        Retro,
        Fashion,
        Uniform,
        Playful,
        Trendy,
        Cute,
        Light,
        MoreLight,
        Fairy,
        Ballroom,
        Royal,
        Linlang,
        Pastoral
    }

    public enum OutfitSet {
        WishfulAurosa,
        SilvergalesAria,
        BubblyVoyage,
        WindOfPurity,
        ByeByeDust,
        AfternoonShine,
        RipplingSerenity,
        FullyCharged,
        FloralMemory,
        SymphonyOfStrings,
        StarletBurst,
        FieryGlow,
        EndlessLonging,
        FarAndAway,
        RebirthWish,
        HometownBreeze,
        StarwishEchoes,
        RefinedGrace,
        ABeautifulDay,
        SearchingForDreams,
        DepartingBlossom,
        CarnivalOde,
        ChicElegance,
        ScarletDream
    }

    public enum FragranceType {
        HairOil,
        BodySpray,
        HandPowder
    }

    public class Sketch
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public int Quality { get; set; } = 1!;

        public int ThreadCost { get; set; } = 0!;

        public int BlingsCost { get; set; } = 0!;

        public SketchSource SketchSource { get; set; } = 0!;

        public SketchCategory SketchCategory { get; set; } = 0!;

        public string MaterialsCost { get; set; } = "[]"!;

        public WardrobeCategory? WardrobeCategory { get; set; }

        public ClothingStyle? ClothingStyle { get; set; }

        public Label[]? Labels { get; set; }

        public OutfitSet? OutfitSet { get; set; }

        public FragranceType? FragranceType { get; set; }
    }
}