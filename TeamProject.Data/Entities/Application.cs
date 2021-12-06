namespace TeamProject.Data.Entities;

public class Application
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string UserId { get; set; }
    public int ProjectId { get; set; }
    public string Status { get; set; }
    public virtual User User { get; set; }
    public virtual Project Project { get; set; }
}