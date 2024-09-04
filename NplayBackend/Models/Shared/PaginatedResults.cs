namespace NplayBackend.Models.Shared;

public class PaginatedResult<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }  // Total elements
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);  // Total pages
    public List<T> Results { get; set; } = new List<T>();
}