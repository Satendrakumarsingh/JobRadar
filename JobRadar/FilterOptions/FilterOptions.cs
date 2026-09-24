namespace JobRadar.Options;

public class FilterOptions
{
    public const string SectionName = "JobFilters";

    public List<string> Keywords { get; set; } = new();

    public List<string> Locations { get; set; } = new();

    public bool RemoteOnly { get; set; }
}