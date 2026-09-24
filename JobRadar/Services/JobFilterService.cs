using JobRadar.Interfaces;
using JobRadar.Models;
using JobRadar.Options;
using Microsoft.Extensions.Options;

namespace JobRadar.Services;

public class JobFilterService : IJobFilter
{
    private readonly FilterOptions _options;

    public JobFilterService(IOptions<FilterOptions> options)
    {
        _options = options.Value;
    }

    public List<Job> Filter(IEnumerable<Job> jobs)
    {
        return jobs
            .Where(Matches)
            .ToList();
    }

    private bool Matches(Job job)
    {
        var keywordMatch =
            KeywordMatcher.Match(
                job,
                _options.Keywords);

        if (!keywordMatch)
        {
            return false;
        }

        var locationMatch =
            _options.Locations.Count == 0 ||
            _options.Locations.Any(location =>
                job.Location.Contains(
                    location,
                    StringComparison.OrdinalIgnoreCase));

        if (!locationMatch)
        {
            return false;
        }

        if (_options.RemoteOnly &&
            !job.Location.Contains(
                "remote",
                StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return true;
    }
}