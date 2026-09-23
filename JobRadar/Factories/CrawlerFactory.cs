using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobRadar.Interfaces;
using JobRadar.Models;

namespace JobRadar.Factories
{
    public class CrawlerFactory : ICrawlerFactory
    {
        private readonly IEnumerable<IJobCrawler> _crawlers;

        public CrawlerFactory(IEnumerable<IJobCrawler> crawlers)
        {
            _crawlers = crawlers;
        }

        public IJobCrawler GetCrawler(CrawlerType crawlerType)
        {
            return _crawlers.First(x => x.AtsType == crawlerType);
        }
    }
}
