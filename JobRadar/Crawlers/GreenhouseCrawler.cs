using System.Text.Json;
using JobRadar.Enums;
using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Crawlers;

public class GreenhouseCrawler : IJobCrawler
{
    private readonly HttpClient _httpClient;
    public CrawlerType AtsType => CrawlerType.Greenhouse;

    public GreenhouseCrawler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Job>> GetJobsAsync(Company company)
    {
        var boardName = company.Url.Split('/').Last();

        var apiUrl =
            $"https://boards-api.greenhouse.io/v1/boards/{boardName}/jobs";

        var json = await _httpClient.GetStringAsync(apiUrl);

        using JsonDocument doc = JsonDocument.Parse(json);

        var jobs = new List<Job>();

        foreach (var item in doc.RootElement
                                .GetProperty("jobs")
                                .EnumerateArray())
        {
            jobs.Add(new Job
            {
                Company = company.Name,
                Title = item.GetProperty("title").GetString() ?? "",
                Url = item.GetProperty("absolute_url").GetString() ?? "",
                Location = item
                    .GetProperty("location")
                    .GetProperty("name")
                    .GetString() ?? ""
            });
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
}