namespace TeamProject.Dto.Responses;

public class JobResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }
    public int ProjectId { get; set; }
    public string? UserName { get; set; }
    public string? UserId { get; set; }
}