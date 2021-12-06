using Microsoft.AspNetCore.Identity;

namespace TeamProject.Data.Entities;

public class User : IdentityUser
{
    public virtual ICollection<Project> Projects { get; set; }
    public virtual ICollection<Job> Jobs { get; set; }
    public virtual ICollection<Application> Applications { get; set; }
    public virtual ICollection<Project> MyProjects { get; set; }
}