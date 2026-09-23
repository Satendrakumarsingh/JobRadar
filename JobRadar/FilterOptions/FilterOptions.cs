namespace JobRadar.Options;

public class FilterOptions
{
    public const string SectionName = "JobFilters";

    public List<string> Keywords { get; set; } = [];

    public List<string> Locations { get; set; } = [];

    public bool RemoteOnly { get; set; }
}