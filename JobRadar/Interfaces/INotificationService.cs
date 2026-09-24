using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface INotificationService
{
    Task NotifyAsync(
        IEnumerable<Job> jobs);
}