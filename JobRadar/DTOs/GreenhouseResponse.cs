using System.Text.Json.Serialization;

namespace JobRadar.Dtos;

public class GreenhouseResponse
{
    [JsonPropertyName("jobs")]
    public List<GreenhouseJobDto> Jobs { get; set; } = new();
}