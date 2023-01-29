namespace Contract.Api.Dto;

public class CreateOrderDto
{
    public List<CreateOrderProductDto> Products { get; set; }
}