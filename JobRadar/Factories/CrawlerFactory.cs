using JobRadar.Enums;
using JobRadar.Interfaces;

namespace JobRadar.Factories;

public class CrawlerFactory : ICrawlerFactory
{
    private readonly IEnumerable<IJobCrawler> _crawlers;

    public CrawlerFactory(IEnumerable<IJobCrawler> crawlers)
    {
        _crawlers = crawlers;
    }

    public IJobCrawler GetCrawler(AtsType atsType)
    {
        var crawler = _crawlers.FirstOrDefault(
            x => x.AtsType == atsType);

        return crawler
            ?? throw new NotSupportedException(
                $"No crawler registered for ATS type '{atsType}'.");
    }
}