using JobRadar.Models;

namespace JobRadar.Services;

public static class KeywordMatcher
{
    public static bool Match(
        Job job,
        IEnumerable<string> keywords)
    {
        var text =
            $"{job.Title} {job.Description}";

        return keywords.Any(keyword =>
            !string.IsNullOrWhiteSpace(keyword) &&
            text.Contains(
                keyword,
                StringComparison.OrdinalIgnoreCase));
    }
}