namespace NikkiApi.Models
{
    public class MaterialsDatabaseSettings : IMaterialsDatabaseSettings
    {
        public string MaterialsCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public interface IMaterialsDatabaseSettings
    {
        string MaterialsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}