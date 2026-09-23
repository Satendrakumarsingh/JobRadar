using JobRadar.Models;

public static class KeywordMatcher
{
    public static bool Match(Job job, IEnumerable<string> keywords)
    {
        string text =
            $"{job.Title} {job.Description}";

        return keywords.Any(keyword =>
            text.Contains(keyword,
                StringComparison.OrdinalIgnoreCase));
    }
}