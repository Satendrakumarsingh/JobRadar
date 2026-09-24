using JobRadar.Crawlers;
using JobRadar.Factories;
using JobRadar.Interfaces;
using JobRadar.Options;
using JobRadar.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<IJobCrawler, GreenhouseCrawler>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);

    client.DefaultRequestHeaders.UserAgent.ParseAdd(
        "JobRadar/1.0");
});

builder.Services.AddSingleton<ICompanyLoader, CompanyLoader>();
builder.Services.AddSingleton<ICrawlerFactory, CrawlerFactory>();
builder.Services.AddSingleton<IJobScannerService, JobScannerService>();
builder.Services.AddSingleton<IJobFilter, JobFilterService>();
builder.Services.AddSingleton<IJobDateFilter, JobDateFilterService>();
builder.Services.AddSingleton<INotificationService, ConsoleNotificationService>();

builder.Services.Configure<FilterOptions>(
    builder.Configuration.GetSection(FilterOptions.SectionName));

builder.Services.Configure<JobSearchOptions>(
    builder.Configuration.GetSection(JobSearchOptions.SectionName));


using var host = builder.Build();

var scanner = host.Services.GetRequiredService<IJobScannerService>();

await scanner.ScanAsync();