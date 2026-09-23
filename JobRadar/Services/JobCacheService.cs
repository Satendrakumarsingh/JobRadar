using System.Text.Json;
using JobRadar.Interfaces;
using JobRadar.Models;
using JobRadar.Options;
using Microsoft.Extensions.Options;

namespace JobRadar.Services;

public class JobCacheService : IJobCacheService
{
    private readonly HashSet<string> _cache = new();
    private readonly IOptions<CacheOptions> _options;

    private readonly string _cacheFile =
        Path.Combine(
            AppContext.BaseDirectory,
            "Cache",
            options.Value.FileName);

    public async Task InitializeAsync()
    {
        if (!File.Exists(_cacheFile))
            return;

        var json = await File.ReadAllTextAsync(_cacheFile);

        if (string.IsNullOrWhiteSpace(json))
            return;

        var keys = JsonSerializer.Deserialize<HashSet<string>>(json);

        if (keys == null)
            return;

        foreach (var key in keys)
        {
            _cache.Add(key);
        }
    }

    public IEnumerable<Job> GetNewJobs(IEnumerable<Job> jobs)
    {
        foreach (var job in jobs)
        {
            if (_cache.Add(GetKey(job)))
            {
                yield return job;
            }
        }
    }

    public async Task SaveAsync()
    {
        Directory.CreateDirectory(
            Path.GetDirectoryName(_cacheFile)!);

        var json = JsonSerializer.Serialize(
            _cache,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(_cacheFile, json);
    }

    private static string GetKey(Job job)
    {
        if (!string.IsNullOrWhiteSpace(job.Id))
            return $"{job.Company}|{job.Id}";

        return $"{job.Company}|{job.Url}";
    }
}