namespace TeamProject.Data.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string RoomName { get; set; }
    public string GithubUrl { get; set; }
    public string OwnerId { get; set; }
    public virtual User Owner { get; set; }
    public virtual ICollection<Job> Jobs { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Application> Applications { get; set; }
}