namespace TeamProject.Dto.Responses;

public class PagedResponse<T>
{
    public List<T> Data { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string NextPage { get; set; }
    public string PreviousPage { get; set; }

    public PagedResponse(List<T> data, int pageNumber, int pageSize)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}