using System.Text.Json.Serialization;

namespace JobRadar.Dtos;

public class GreenhouseLocationDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
}