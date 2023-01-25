using Mapster;
using Merchant.Api.Data;
using Merchant.Api.Dtos;
using Merchant.Api.Entities;
using Merchant.Api.Exceptions;
using Merchant.Api.Repositories;

namespace Merchant.Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IOrganizationRepository organizationRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, 
        IOrganizationRepository organizationRepository)
    {
        this.employeeRepository = employeeRepository;
        this.organizationRepository = organizationRepository;
    }


    public async Task<EmployeeView> GetEmployeeByIdAsync(Guid organizationId, Guid employeeId)
    {
        var organization = await organizationRepository.GetOrganizationByIdAsync(organizationId);
        if (organization is null)
            throw new NotFoundException<Organization>();

        var employee = await employeeRepository.GetEmployeeByIdAsync(employeeId);
        if (employee == null)
            throw new NotFoundException<AppUser>();

        if (!employee.Users.Any(x => x.OrganizationId == organizationId))
            throw new NotFoundException<OrganizationUser>();

        var result = employee.Adapt<EmployeeView>();
        result.Role = employee.Users.First(x => x.OrganizationId == organizationId).Role;
        return result;

    }


    public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployee)
    {
        var organization = await organizationRepository.GetOrganizationByIdAsync(createEmployee.OrganizationId);
        if (organization is null)
            throw new NotFoundException<Organization>();

        var organizationUser = new OrganizationUser()
        {
            OrganizationId = createEmployee.OrganizationId,
            Role = createEmployee.Role
        };

        // need to find userId by userEmail from User.api and get userId and userName and then need to save into AppUser table
        var userId = Guid.NewGuid();
        var userName = Guid.NewGuid().ToString();

        var user = await employeeRepository.GetEmployeeByEmailAsync(createEmployee.Email);
        if (user is null)
        {
            user = new AppUser()
            {
                Id = userId,
                UserName = userName,
                Email = createEmployee.Email,
                Users = new List<OrganizationUser>()
                {
                    organizationUser
                }

            };
            await employeeRepository.CreateEmployeeAsync(user);
        }
        else
        {
            user.Users!.Add(organizationUser);
            await employeeRepository.UpdateEmployeeAsync(user);

        }
    }


    public async Task DeleteEmployeeAsync(Guid organizationId, Guid employeeId)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(employeeId);
        if (!employee.Users.Any(x => x.OrganizationId == organizationId))
            throw new NotFoundException<OrganizationUser>();

        await employeeRepository.DeleteEmployeeAsync(employee);
    }

    public async Task UpdatEmployeeAsync(Guid organizationId, Guid employeeId, UpdateEmployeeDto updateEmployee)
    {
        var organization = await organizationRepository.GetOrganizationByIdAsync(organizationId);
        if (organization is null)
            throw new NotFoundException<Organization>();

        var employee = await employeeRepository.GetEmployeeByIdAsync(employeeId);
        if (employee is null)
            throw new NotFoundException<AppUser>();

        if (!employee.Users.Any(x => x.OrganizationId == organizationId))
            throw new NotFoundException<OrganizationUser>();
        employee.Users.First(x => x.OrganizationId == organizationId).Role = updateEmployee.Role;

        await employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task<List<EmployeeView>?> GetEmployeesAsync(Guid organizationId)
    {
        var organization = await organizationRepository.GetOrganizationByIdAsync(organizationId);
        if (organization is null)
            throw new NotFoundException<Organization>();

        var result = new List<EmployeeView>();
        var employee = new EmployeeView();
        foreach (var organizationUser in organization.Users)
        {
            employee = organizationUser.User!.Adapt<EmployeeView>();
            employee.Role = organizationUser.Role;
            result.Add(employee);
        }
        return result;
    }

}
