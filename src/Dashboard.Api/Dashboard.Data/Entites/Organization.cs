namespace Dashboard.Data.Entites;

public class Organization
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EOrganizationStatus Status { get; set; }
    public virtual ICollection<OrganizationUser>? Users { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}