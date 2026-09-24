# JobRadar

JobRadar is a .NET-based job monitoring application that scans company career pages and ATS platforms for software engineering opportunities.

## Current Features

- Company configuration through JSON
- Greenhouse job board crawling
- Job keyword filtering
- Location filtering
- Remote-only filtering
- Duplicate job detection using a local cache
- Console notifications for newly discovered jobs
- Dependency injection using .NET Generic Host
- Extensible crawler factory architecture

## Architecture

```text
companies.json
      |
      v
CompanyLoader
      |
      v
JobScannerService
      |
      v
CrawlerFactory
      |
      v
GreenhouseCrawler
      |
      v
Job
      |
      v
JobFilterService
      |
      v
JobCacheService
      |
      v
ConsoleNotificationService
