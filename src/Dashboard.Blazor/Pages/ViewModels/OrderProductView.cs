using System;
namespace Dashboard.Blazor.ViewModels
{
	public class OrderProductView
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public uint Count { get; set; }
		public string? Properties { get; set; }
	}
}

