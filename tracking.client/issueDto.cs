
namespace tracking.client{

internal class issueDto
{
    public int id { get; set; }
    public String title{ get; set; }
    public String description{ get; set; }
    public Priority Priority { get; set; }
    public IssueType IssueType { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Completed { get; set; }
}

public enum Priority
{
    Low,
    Medium,
    High
}

public enum IssueType
{
    Feature,Bug,Documentation
}

}