using Product.Api.Entities.Enums;
using Product.Api.Filters;

namespace Product.Api.Entities.Dtos
{
	public class ProductFilterDto : PaginationParams
	{
		public string? Name { get; set; }
		public decimal? FromPrice { get; set; }
		public decimal? ToPrice { get; set; }
		public EProductStatus Status { get; set; }
		public EProductSortingStatus SortingStatus { get; set; }
	}
}
