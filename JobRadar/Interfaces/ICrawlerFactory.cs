using JobRadar.Models;

namespace JobRadar.Interfaces;

public interface ICrawlerFactory
{
    IJobCrawler GetCrawler(CrawlerType crawlerType);
}