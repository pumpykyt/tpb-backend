namespace TeamProject.Domain.Data.Entities;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }
    public int ProjectId { get; set; }
    public string? UserId { get; set; }
    public virtual Project Project { get; set; }
    public virtual User User { get; set; }
}