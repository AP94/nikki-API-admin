namespace NikkiApi.Models
{
    public class MaterialSourcesDatabaseSettings : IMaterialSourcesDatabaseSettings
    {
        public string MaterialSourcesCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public interface IMaterialSourcesDatabaseSettings
    {
        string MaterialSourcesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}