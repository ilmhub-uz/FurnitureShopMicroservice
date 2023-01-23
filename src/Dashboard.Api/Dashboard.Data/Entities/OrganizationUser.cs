using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Data.Entities;

public class OrganizationUser
{
    public string UserId { get; set; }
    public string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    public ERole Role { get; set; }
}
