using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Services;

public class JobScannerService : IJobScannerService
{
    private readonly ICompanyLoader _companyLoader;
    private readonly ICrawlerFactory _crawlerFactory;
    private readonly IJobFilter _jobFilter;
    private readonly IJobCacheService _jobCacheService;
    private readonly INotificationService _notificationService;

    public JobScannerService(
    ICompanyLoader companyLoader,
    ICrawlerFactory crawlerFactory,
    IJobFilter jobFilter,
    IJobCacheService jobCacheService,
    INotificationService notificationService)
    {
        _companyLoader = companyLoader;
        _crawlerFactory = crawlerFactory;
        _jobFilter = jobFilter;
        _jobCacheService = jobCacheService;
        _notificationService = notificationService;
    }

    public async Task ScanAsync()
    {
        await _jobCacheService.InitializeAsync();

        var companies = await _companyLoader.LoadCompaniesAsync();

        foreach (var company in companies)
        {
            await ScanCompanyAsync(company);
        }

        await _jobCacheService.SaveAsync();
    }

    private async Task ScanCompanyAsync(Company company)
    {
        var jobs = await crawler.GetJobsAsync(company);

        jobs = _jobFilter.Filter(jobs);

        var newJobs = _jobCacheService.GetNewJobs(jobs).ToList();

        await _notificationService.NotifyAsync(newJobs);
    }
}