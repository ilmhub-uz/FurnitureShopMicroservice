using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Data.Entities;

public class Organization
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public EOrganizationStatus Status { get; set; }
    public virtual ICollection<OrganizationUser>? Users { get; set; }
}
