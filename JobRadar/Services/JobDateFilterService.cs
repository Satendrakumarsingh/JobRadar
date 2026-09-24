using JobRadar.Interfaces;
using JobRadar.Models;
using JobRadar.Options;
using Microsoft.Extensions.Options;

namespace JobRadar.Services;

public class JobDateFilterService : IJobDateFilter
{
    private readonly JobSearchOptions _options;

    public JobDateFilterService(
        IOptions<JobSearchOptions> options)
    {
        _options = options.Value;
    }

    public List<Job> Filter(IEnumerable<Job> jobs)
    {
        var cutoffDate =
            DateTime.UtcNow.AddDays(-_options.MaxJobAgeDays);

        return jobs
            .Where(job =>
                job.PostedDate.HasValue &&
                job.PostedDate.Value >= cutoffDate)
            .ToList();
    }
}