using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Services;

public class ConsoleNotificationService : INotificationService
{
    public Task NotifyAsync(IEnumerable<Job> jobs)
    {
        foreach (var job in jobs)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("NEW JOB FOUND");

            Console.ResetColor();

            Console.WriteLine($"Company  : {job.Company}");
            Console.WriteLine($"Title    : {job.Title}");
            Console.WriteLine($"Location : {job.Location}");
            Console.WriteLine($"URL      : {job.Url}");

            Console.WriteLine(
                new string('-', 60));
        }

        return Task.CompletedTask;
    }
}