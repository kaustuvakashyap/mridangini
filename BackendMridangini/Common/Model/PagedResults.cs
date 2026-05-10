using System.Collections;
using BackendMridangini.eShop.Core.Products.DTOs;

namespace BackendMridangini.Common.Model;

public class PagedResult<T> : IEnumerable<ProductDto>
{
    public IEnumerable<T> Data { get; set; }
        = [];

    public PaginationMeta Meta { get; set; }
        = new();

    public IEnumerator<ProductDto> GetEnumerator()
    {
        throw new NotImplementedException();
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
