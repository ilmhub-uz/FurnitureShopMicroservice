using System.ComponentModel.DataAnnotations.Schema;
namespace Contract.Api.Entities;

public class ContractOrder
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid ContractId { get; set; }
    public uint Count { get; set; }
    public string? Properties { get; set; }
}