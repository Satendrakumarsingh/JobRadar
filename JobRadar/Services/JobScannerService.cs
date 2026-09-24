using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Services;

public class JobScannerService : IJobScannerService
{
    private readonly ICompanyLoader _companyLoader;
    private readonly ICrawlerFactory _crawlerFactory;
    private readonly IJobDateFilter _jobDateFilter;
    private readonly IJobFilter _jobFilter;
    private readonly INotificationService _notificationService;

    public JobScannerService(
        ICompanyLoader companyLoader,
        ICrawlerFactory crawlerFactory,
        IJobDateFilter jobDateFilter,
        IJobFilter jobFilter,
        INotificationService notificationService)
    {
        _companyLoader = companyLoader;
        _crawlerFactory = crawlerFactory;
        _jobDateFilter = jobDateFilter;
        _jobFilter = jobFilter;
        _notificationService = notificationService;
    }

    public async Task ScanAsync()
    {
        var companies =
            await _companyLoader.LoadCompaniesAsync();

        foreach (var company in companies)
        {
            Console.WriteLine();
            Console.WriteLine($"Scanning {company.Name}");

            try
            {
                await ScanCompanyAsync(company);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(
                    $"Failed scanning {company.Name}: {ex.Message}");

                Console.ResetColor();
            }
        }
    }

    private async Task ScanCompanyAsync(Company company)
    {
        var crawler =
            _crawlerFactory.GetCrawler(company.AtsType);

        var jobs =
            await crawler.GetJobsAsync(company);

        Console.WriteLine(
            $"Jobs found: {jobs.Count}");

        var recentJobs =
            _jobDateFilter.Filter(jobs);

        Console.WriteLine(
            $"Jobs in last configured period: {recentJobs.Count}");

        var filteredJobs =
            _jobFilter.Filter(recentJobs);

        Console.WriteLine(
            $"Jobs after keyword/location filter: {filteredJobs.Count}");

        await _notificationService.NotifyAsync(filteredJobs);
    }
}