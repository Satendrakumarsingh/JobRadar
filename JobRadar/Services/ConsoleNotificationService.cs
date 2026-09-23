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

            Console.WriteLine(job.Company);
            Console.WriteLine(job.Title);
            Console.WriteLine(job.Location);
            Console.WriteLine(job.Url);

            Console.WriteLine(new string('-', 60));
        }

        return Task.CompletedTask;
    }
}