using Merchant.Api.Dtos;
using System.Security.Claims;

namespace Merchant.Api.Services;

public interface IEmployeeService
{
    Task CreateEmployeeAsync(CreateEmployeeDto createEmployee);
    Task<List<EmployeeView>?> GetEmployeesAsync(Guid organizationId);
    Task<EmployeeView> GetEmployeeByIdAsync(Guid OrganizationId,Guid employeeId);
    Task UpdatEmployeeAsync(Guid organizationId,Guid employeeId, UpdateEmployeeDto updateEmployee);
    Task DeleteEmployeeAsync(Guid OrganizationId,Guid employeeId);
}
