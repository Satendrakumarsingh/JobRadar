using System.Text.Json.Serialization;

namespace JobRadar.Dtos;

public class GreenhouseJobDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = "";

    [JsonPropertyName("absolute_url")]
    public string Url { get; set; } = "";

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("location")]
    public GreenhouseLocationDto Location { get; set; } = new();
  
    [JsonPropertyName("content")]
    public string Description { get; set; } = "";
}