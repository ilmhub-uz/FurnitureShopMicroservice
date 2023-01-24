using Mapster;
using Merchant.Api.Context;
using Merchant.Api.Dtos;
using Merchant.Api.Entities;
using Merchant.Api.Exceptions;
using Merchant.Api.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Merchant.Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext context;

    public EmployeeService(
        AppDbContext context)
    {
        this.context = context;
    }


    public async Task<EmployeeView> GetEmployeeByIdAsync(Guid organizationId,Guid employeeId)
    {
        var organizationUsers = await context.OrganizationUsers.FirstOrDefaultAsync(x => x.OrganizationId == organizationId && x.UserId == employeeId);
        if (organizationUsers is null)
            throw new NotFoundException<OrganizationUser>();

        var user = organizationUsers.User;

        var userView = organizationUsers.User!.Adapt<EmployeeView>();
        userView.Role = organizationUsers.Role;
        return userView;
    }


    public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployee)
    {
        var organization = await context.Organizations.FirstOrDefaultAsync(x=> x.Id == createEmployee.OrganizationId);
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

        var user =await context.AppUsers.FirstOrDefaultAsync(x=> x.Email == createEmployee.Email);   
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
            await context.AppUsers.AddAsync(user);
            await context.SaveChangesAsync();
        }
        else
        {
            user.Users!.Add(organizationUser);
            context.AppUsers.Update(user);
            
        }
        await context.SaveChangesAsync();
    }


    public async Task DeleteEmployeeAsync(Guid organizationId, Guid employeeId)
    {
        var organizationUsers =await context.OrganizationUsers.FirstOrDefaultAsync(x=>x.OrganizationId == organizationId && x.UserId == employeeId);
        if (organizationUsers is null)
            throw new NotFoundException<OrganizationUser>();
        context.OrganizationUsers.Remove(organizationUsers);
        await context.SaveChangesAsync();
    }

    public async Task UpdatEmployeeAsync(Guid organizationId, Guid employeeId, UpdateEmployeeDto updateEmployee)
    {
        var organizationUsers = await context.OrganizationUsers.FirstOrDefaultAsync(x => x.OrganizationId == organizationId && x.UserId == employeeId);
        if (organizationUsers is null)
            throw new NotFoundException<OrganizationUser>();

        organizationUsers.Role = updateEmployee.Role;
        // organizationUsers.OrganizationId = updateEmployee.OrganizationId; 
        // there is a problem

        context.OrganizationUsers.Update(organizationUsers);
        await context.SaveChangesAsync();
    }

    public async Task<List<EmployeeView>?> GetEmployeesAsync(Guid organizationId)
    { 
        var organizationUsers = await context.OrganizationUsers.Where(x => x.OrganizationId == organizationId).ToListAsync();

        var employees = new List<EmployeeView>();
        var employee = new EmployeeView();
        foreach(var organizationUser in organizationUsers)
        {
            employee = organizationUser.User!.Adapt<EmployeeView>();
            employee.Role = organizationUser.Role;
            employees.Add(employee);    
        }
        return employees;
    }

}
