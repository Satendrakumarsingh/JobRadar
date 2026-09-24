using System.Text.Json;
using System.Text.Json.Serialization;
using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Services;

public class CompanyLoader : ICompanyLoader
{
    public async Task<List<Company>> LoadCompaniesAsync()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "Config",
            "companies.json");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                "Company configuration file was not found.",
                path);
        }

        var json = await File.ReadAllTextAsync(path);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        options.Converters.Add(
            new JsonStringEnumConverter());

        return JsonSerializer.Deserialize<List<Company>>(
                   json,
                   options)
               ?? new List<Company>();
    }
}