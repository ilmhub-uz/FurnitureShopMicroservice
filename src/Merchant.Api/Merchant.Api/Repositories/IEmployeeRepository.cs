using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public interface IEmployeeRepository
{
    Task CreateEmployeeAsync(AppUser createEmployee);
    Task UpdateEmployeeAsync(AppUser updateEmployee);
    Task DeleteEmployeeAsync(AppUser deleteEmployee);
    Task<AppUser?> GetEmployeeByIdAsync(Guid EmployeeId);
    Task<AppUser?> GetEmployeeByEmailAsync(string email);
    Task<List<AppUser>?> GetEmployees();
}
