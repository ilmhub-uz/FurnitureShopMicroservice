using Contract.Api.Entities;

namespace Contract.Api.ViewModel
{
    public class OrderProductView
    {
        public Guid Id { get; set; }

        public EOrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public virtual ICollection<OrderProductView>? OrderProducts { get; set; }
    }
}
