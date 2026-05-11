using System.Collections;

namespace BackendMridangini.Common.Model;

public class PagedResult<T> : IEnumerable<T>
{
    public IEnumerable<T> Data { get; set; }
        = [];

    public PaginationMeta Meta { get; set; }
        = new();

    public IEnumerator<T> GetEnumerator()
    {
        return Data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class PaginationMeta
{
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public int TotalPages { get; set; }
}