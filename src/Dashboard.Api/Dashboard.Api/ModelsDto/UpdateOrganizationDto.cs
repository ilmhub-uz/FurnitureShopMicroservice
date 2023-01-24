using Dashboard.Data.Entities;

namespace Dashboard.Api.ModelsDto;

public class UpdateOrganizationDto
{
    public string? Name { get; set; }
    public EOrganizationStatus Status { get; set; }
}
