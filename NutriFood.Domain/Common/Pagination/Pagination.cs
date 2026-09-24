namespace NutriFood.Domain.Common.Pagination;

public sealed class Pagination
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 10;
    public const int MaxPageSize = 100;

    public int Page { get; }

    public int PageSize { get; }

    public int Skip => (int)Math.Min((long)(Page - 1) * PageSize, int.MaxValue);

    public Pagination(int page, int pageSize)
    {
        Page = page <= 0 ? DefaultPage : page;
        PageSize = pageSize <= 0
            ? DefaultPageSize
            : Math.Min(pageSize, MaxPageSize);
    }
}
