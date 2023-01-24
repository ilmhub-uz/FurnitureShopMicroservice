using Product.Api.Entities.Enums;

namespace Product.Api.Entities.Dtos
{
	public class UpdateProductDto
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public bool? WithInstallation { get; set; }
		public string? Brend { get; set; }
		public string? Material { get; set; }
		public decimal Price { get; set; }
		public bool IsAvailable { get; set; }
		public uint Count { get; set; }
		public EProductStatus Status { get; set; }
	}
}
