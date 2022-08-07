using System.ComponentModel.DataAnnotations;

namespace trackingAPI.Models
{

    public class Issue
    {
        public int id { get; set; }
        [Required]
        public String title{ get; set; }
        [Required]
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