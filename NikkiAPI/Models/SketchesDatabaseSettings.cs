namespace NikkiApi.Models
{
    public class SketchesDatabaseSettings : ISketchesDatabaseSettings
    {
        public string SketchesCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public interface ISketchesDatabaseSettings
    {
        string SketchesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}