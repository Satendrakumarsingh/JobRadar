using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobRadar.Interfaces;
using JobRadar.Models;
using JobRadar.Options;
using Microsoft.Extensions.Options;

namespace JobRadar.Services
{
    public class JobFilterService : IJobFilter
    {
        private readonly FilterOptions _options;

        public JobFilterService(IOptions<FilterOptions> options)
        {
            _options = options.Value;
        }
        public List<Job> Filter(IEnumerable<Job> jobs)
        {
            return jobs.Where(job =>
            {
                bool keywordMatch =
                      KeywordMatcher.Match(job, _options.Keywords);

                bool locationMatch =
                    _options.Locations.Count == 0 ||
                    _options.Locations.Any(location =>
                        job.Location.Contains(location,
                            StringComparison.OrdinalIgnoreCase));

                return keywordMatch && locationMatch;
            }).ToList();
        }
    }
}
