using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface ICompanyLoader
{
    Task<List<Company>> LoadCompaniesAsync();
}