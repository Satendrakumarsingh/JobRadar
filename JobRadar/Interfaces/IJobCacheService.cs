using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface IJobCacheService
{
    Task InitializeAsync();

    IEnumerable<Job> GetNewJobs(IEnumerable<Job> jobs);

    Task SaveAsync();
}