namespace JobRadar.Models;

public class Job
{
    public string Id { get; set; } = string.Empty;

    public string Company { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public DateTime? PostedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string EmploymentType { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;
}