using JobRadar.Enums;
using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface IJobCrawler
{
    CrawlerType AtsType { get; }

    Task<List<Job>> GetJobsAsync(Company company);
}