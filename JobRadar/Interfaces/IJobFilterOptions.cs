using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface IFilterLoader
{
    Task<JobFilterOptions> LoadAsync();
}