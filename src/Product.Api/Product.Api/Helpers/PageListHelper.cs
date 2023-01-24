using Product.Api.Filters;
using Newtonsoft.Json;
namespace Product.Api.Helpers
{
	public static class PageListHelper
	{
		public static async Task<IEnumerable<T>> ToPagedListAsync<T>(this IQueryable<T> source, PaginationParams pageParams)
		{
			pageParams ??= new PaginationParams();

			HttpContextHelper.AddResponseHeader("X-Pagination",
				JsonConvert.SerializeObject(new PaginationMetaData(source.Count(), pageParams.Size, pageParams.Page)));

			return  source.Skip(pageParams.Size * (pageParams.Page - 1)).Take(pageParams.Size).ToList();
		}

		public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams pageParams)
		{
			pageParams ??= new PaginationParams();

			HttpContextHelper.AddResponseHeader("X-Pagination",
				JsonConvert.SerializeObject(new PaginationMetaData(source.Count(), pageParams.Size, pageParams.Page)));

			return source.Skip(pageParams.Size * (pageParams.Page - 1)).Take(pageParams.Size).ToList();
		}
	}
}
