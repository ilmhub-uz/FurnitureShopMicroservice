using Dashboard.Blazor.ModelsDto.Enums;



namespace Dashboard.Blazor.ModelsDto;

public class UpdateOrganizationDto
{
    public string? Name { get; set; }
    public EOrganizationStatus Status { get; set; }
}
