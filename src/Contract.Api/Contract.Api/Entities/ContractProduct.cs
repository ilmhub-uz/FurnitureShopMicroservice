using System.ComponentModel.DataAnnotations.Schema;
namespace Contract.Api.Entities;

public class ContractProduct
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid ContractId { get; set; }
    [ForeignKey("ContractId")]
    public virtual Contract? Contract { get; set; }
    public uint Count { get; set; }
    public string? Properties { get; set; }
}