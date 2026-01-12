namespace InnoChess.Application.Pagination;

public class PagedResult<T> (IEnumerable<T> items, int total)
{
    public IEnumerable<T> Items { get; } = items;
    public int Total { get; set; } = total;
}