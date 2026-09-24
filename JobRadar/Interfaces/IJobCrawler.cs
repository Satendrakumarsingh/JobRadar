using JobRadar.Enums;
using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface IJobCrawler
{
    AtsType AtsType { get; }

    Task<List<Job>> GetJobsAsync(Company company);
}