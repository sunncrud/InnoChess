namespace InnoChess.Application.Pagination;

public record PageParams(int Page = 1, int PageSize = 10)
{
    public int Page { get; init; } = Page;
    public int PageSize { get; init; } = PageSize;
}