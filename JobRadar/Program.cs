using JobRadar.Interfaces;
using JobRadar.Services;
using JobRadar.Crawlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JobRadar.Options;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddSingleton<ICompanyLoader, CompanyLoader>();
builder.Services.AddSingleton<ICrawlerFactory, CrawlerFactory>();
builder.Services.AddSingleton<IJobScannerService, JobScannerService>();
builder.Services.AddHttpClient<IJobCrawler, GreenhouseCrawler>();
builder.Services.AddSingleton<IJobFilter, JobFilterService>();
//builder.Services.AddSingleton<IFilterLoader, FilterLoader>(); removed
builder.Services.AddSingleton<IJobCacheService, JobCacheService>();
builder.Services.AddSingleton<INotificationService, ConsoleNotificationService>();
builder.Services.Configure<FilterOptions>(
    builder.Configuration.GetSection(FilterOptions.SectionName));
builder.Services.Configure<CacheOptions>(
    builder.Configuration.GetSection(CacheOptions.SectionName));

var host = builder.Build();

var scanner = host.Services.GetRequiredService<IJobScannerService>();

await scanner.ScanAsync();