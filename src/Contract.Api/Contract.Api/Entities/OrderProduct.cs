using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Api.Entities
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        public uint Count { get; set; }
        public string? Properties { get; set; }
    }  
}
