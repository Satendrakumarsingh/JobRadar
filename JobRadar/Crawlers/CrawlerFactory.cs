using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Crawlers;

public class CrawlerFactory : ICrawlerFactory
{
    private readonly GreenhouseCrawler _greenhouseCrawler;

    public CrawlerFactory(
        GreenhouseCrawler greenhouseCrawler)
    {
        _greenhouseCrawler = greenhouseCrawler;
    }

    public IJobCrawler GetCrawler(CrawlerType crawlerType)
    {
        return crawlerType switch
        {
            CrawlerType.Greenhouse => _greenhouseCrawler,

            _ => throw new NotSupportedException(
                $"{crawlerType} crawler not implemented.")
        };
    }
}