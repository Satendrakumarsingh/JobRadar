using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface IJobFilter
{
    List<Job> Filter(
        IEnumerable<Job> jobs);
}