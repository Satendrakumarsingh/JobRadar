using JobRadar.Enums;

namespace JobRadar.Interfaces;

public interface ICrawlerFactory
{
    IJobCrawler GetCrawler(AtsType atsType);
}