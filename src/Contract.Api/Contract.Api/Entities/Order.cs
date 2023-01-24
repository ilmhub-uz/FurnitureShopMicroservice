using Microsoft.PowerBI.Api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Api.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public EOrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
