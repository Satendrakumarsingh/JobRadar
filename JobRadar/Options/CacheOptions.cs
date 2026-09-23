namespace JobRadar.Options;

public class CacheOptions
{
    public const string SectionName = "Cache";

    public string FileName { get; set; } = "jobs-cache.json";
}