namespace TeamProject.Dto.Responses;

public class ApplicationResponse
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string Status { get; set; }
    public string UserId { get; set; }
    public int ProjectId { get; set; }
}