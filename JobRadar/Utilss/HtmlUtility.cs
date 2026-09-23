using System.Text.RegularExpressions;

namespace JobRadar.Utils;

public static class HtmlUtility
{
    public static string StripHtml(string html)
    {
        if (string.IsNullOrWhiteSpace(html))
            return string.Empty;

        return Regex.Replace(html, "<.*?>", " ");
    }
}