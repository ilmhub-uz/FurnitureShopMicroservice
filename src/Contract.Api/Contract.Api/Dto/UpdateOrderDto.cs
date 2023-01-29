using Contract.Api.Entities;

namespace Contract.Api.Dto;

public class UpdateOrderDto
{
    public EOrderStatus? OrderStatus { get; set; }
}