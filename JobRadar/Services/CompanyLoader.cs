using System.Text.Json;
using JobRadar.Interfaces;
using JobRadar.Models;
using System.Text.Json.Serialization;

namespace JobRadar.Services;

public class CompanyLoader : ICompanyLoader
{
    public async Task<List<Company>> LoadCompaniesAsync()
    {
        var path = Path.Combine(AppContext.BaseDirectory,
            "Config",
            "companies.json");

        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        var json = await File.ReadAllTextAsync(path);

        //Console.WriteLine(json);

        // return JsonSerializer.Deserialize<List<Company>>( json,
        // new JsonSerializerOptions
        // {
        //     PropertyNameCaseInsensitive = true
        // }) ?? new List<Company>();
        ///BELOW Greenhouise becomes => CrawlerType.Greenhouse
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        options.Converters.Add(new JsonStringEnumConverter());

        return JsonSerializer.Deserialize<List<Company>>(json, options)
            ?? new List<Company>();
    }
}