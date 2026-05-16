using System.Collections;

namespace BackendMridangini.Common.Model;

/**
 * <summary>Represents a paged result set.</summary>
 * <typeparam name="T">The type of elements in the result set.</typeparam>
 */
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
/**
 * <summary>Represents the metadata for pagination.</summary>
 * <remarks>
 * This class contains information about the current page, page size, total count of items, and total number of pages.
 * It is used in conjunction with the PagedResult class to provide pagination information to clients when returning paged results from the API.
 * The CurrentPage property indicates the current page number being returned, while the PageSize property indicates how many items are included in each page.
 *</remarks>
 */
public class PaginationMeta
{
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public int TotalPages { get; set; }
}