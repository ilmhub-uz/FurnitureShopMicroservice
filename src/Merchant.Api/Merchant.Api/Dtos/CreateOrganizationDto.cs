using Merchant.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace Merchant.Api.Dtos;

public class CreateOrganizationDto
{
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? ImageUrl { get; set; }
}