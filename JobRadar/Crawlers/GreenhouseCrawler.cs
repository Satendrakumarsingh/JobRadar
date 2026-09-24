using System.Net.Http.Json;
using JobRadar.Dtos;
using JobRadar.Enums;
using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Crawlers;

public class GreenhouseCrawler : IJobCrawler
{
    private readonly HttpClient _httpClient;

    public AtsType AtsType => AtsType.Greenhouse;

    public GreenhouseCrawler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Job>> GetJobsAsync(Company company)
    {
        var boardName = GetBoardName(company.Url);

        var apiUrl =
            $"https://boards-api.greenhouse.io/v1/boards/{boardName}/jobs?content=true";

        Console.WriteLine($"Company: {company.Name}");
        Console.WriteLine($"Board: {boardName}");
        Console.WriteLine($"API: {apiUrl}");

        var httpResponse = await _httpClient.GetAsync(apiUrl);

        httpResponse.EnsureSuccessStatusCode();

        var response = await httpResponse.Content.ReadFromJsonAsync<GreenhouseResponse>();

        if (response is null)
        {
            throw new InvalidOperationException(
                $"Greenhouse returned an empty response for '{company.Name}'.");
        }

        return response.Jobs.Select(job => new Job
        {
            Id = job.Id.ToString(),
            Company = company.Name,
            Title = job.Title,
            Description = job.Description,
            Location = job.Location.Name,
            Url = job.Url,
            UpdatedDate = job.UpdatedAt
        }).ToList();
    }

    private static string GetBoardName(string companyUrl)
    {
        var uri = new Uri(companyUrl);

        var segments = uri.AbsolutePath
            .Trim('/')
            .Split('/', StringSplitOptions.RemoveEmptyEntries);

        if (segments.Length == 0)
        {
            throw new ArgumentException(
                $"Invalid Greenhouse URL: '{companyUrl}'.");
        }

        return segments[0];
    }
}