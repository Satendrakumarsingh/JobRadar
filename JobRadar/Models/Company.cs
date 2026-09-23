namespace JobRadar.Models;

public class Company
{
    public string Name { get; set; } = string.Empty;

    public CrawlerType AtsType { get; set; }

    public string Url { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = new();
}