namespace Dashboard.Api.ViewModels;

public class UserView
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public virtual ICollection<OrganizationUserView>? Users { get; set; }
}