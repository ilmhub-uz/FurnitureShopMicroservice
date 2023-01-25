
namespace Contract.Api.Dto
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public uint ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
