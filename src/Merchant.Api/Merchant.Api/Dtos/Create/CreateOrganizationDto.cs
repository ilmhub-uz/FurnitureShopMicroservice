using Merchant.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace Merchant.Api.Dtos.Create;

public class CreateOrganizationDto
{
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? ImageUrl { get; set; }
}