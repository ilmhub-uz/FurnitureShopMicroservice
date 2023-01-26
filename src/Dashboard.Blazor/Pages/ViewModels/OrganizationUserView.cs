namespace Dashboard.Blazor.ViewModels;

public class OrganizationUserView
{
    public Guid UserId { get; set; }
    public Guid OrganizationId { get; set; }
    public ERole Role { get; set; }
}

public enum ERole
{
    Owner,
    Manager,
    Seller
}
