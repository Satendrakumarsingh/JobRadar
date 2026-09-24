using JobRadar.Enums;

namespace JobRadar.Models;

public class Company
{
    public string Name { get; set; } = string.Empty;

    public AtsType AtsType { get; set; }

    public string Url { get; set; } = string.Empty;

    public Dictionary<string, string> Metadata { get; set; } = new();
}