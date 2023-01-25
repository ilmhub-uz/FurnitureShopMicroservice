namespace Contract.Api.Dto
{
    public class CreateOrderProductDto
    {

        public Guid ProductId { get; set; }
        public uint Count { get; set; }
    }
}
