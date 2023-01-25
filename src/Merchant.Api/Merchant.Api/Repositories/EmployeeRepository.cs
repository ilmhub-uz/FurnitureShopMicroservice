using Merchant.Api.Data;
using Merchant.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Api.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext context;

    public EmployeeRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CreateEmployeeAsync(AppUser createEmployee)
    {
        await context.AppUsers!.AddAsync(createEmployee);
        await context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(AppUser deleteEmployee)
    {
        context.AppUsers.Remove(deleteEmployee);
        await context.SaveChangesAsync();
    }

    public async Task<AppUser?> GetEmployeeByEmailAsync(string email)
    {
        var employeee = await context.AppUsers.FirstOrDefaultAsync(x => x.Email == email);
        return employeee;
    }

    public async Task<AppUser?> GetEmployeeByIdAsync(Guid EmployeeId)
    {
        var employeee = await context.AppUsers.FirstOrDefaultAsync(x => x.Id == EmployeeId);
        return employeee;
    }

    public async Task<List<AppUser>?> GetEmployees()
    {
        var employeees = await context.AppUsers.ToListAsync();
        return employeees;
    }

    public async Task UpdateEmployeeAsync(AppUser updateEmployee)
    {
        context.AppUsers.Update(updateEmployee);
        await context.SaveChangesAsync();
    }
}
