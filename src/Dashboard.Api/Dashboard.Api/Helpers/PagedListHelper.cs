using Dashboard.Api.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Dashboard.Api.Helpers;

public static class PagedListHelper
{
    public static async Task<IEnumerable<T>> TopagedListAsync<T>(this IQueryable<T> source, PaginationParams pageParams)
    {
        pageParams ??= new PaginationParams();
        
        HttpContextHelper.AddResponseHeader("X-Pagination",
            JsonConvert.SerializeObject(new PaginationMetaData(source.Count(), pageParams.Size, pageParams.Page)));
        return await source.Skip(pageParams.Size * (pageParams.Page - 1)).Take(pageParams.Size).ToListAsync();
    }
}