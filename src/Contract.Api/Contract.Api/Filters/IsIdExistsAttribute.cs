using Contract.Api.Context;
using Contract.Api.Context.Repositories;
using Contract.Api.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Contract.Api.Filters;

public class IsIdExistsAttribute : ActionFilterAttribute
{
    private readonly AppDbContext dbcontext;

    private const string targetClass = "Repository";
    private readonly string notFoundRepositoryExceptionMessage = "Repository based on given parameter has not been found!";
    private readonly string noParametersFoundExceptionMessage = "Error! Any parameters about ID have not been found";

    public IsIdExistsAttribute(AppDbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var parameters = context.ActionArguments.Where(a => a.Key.ToLower().Contains("id"))
            .ToDictionary(c => c.Key, c => c.Value);
        
        if (parameters.Keys.Count() <= 0)
        {
            throw new NotFoundException(noParametersFoundExceptionMessage);
        }

        var normalizedParameters = Normalizer(parameters);

        if (normalizedParameters.Any(kvp => FindTypeByName(kvp.Key + targetClass) is null))
        {
            throw new BadHttpRequestException(notFoundRepositoryExceptionMessage);
        }

        var classTypes = new Dictionary<Type, object?>();

        foreach (var kvp in normalizedParameters)
        {
            var classname = kvp.Key + targetClass;
            classTypes.Add(FindTypeByName(classname)!, kvp.Value);
        }

        var results = new List<bool>();

        foreach (var classType in classTypes)
        {
            var Id = (Guid)classType.Value!;
            var instances = Activator.CreateInstance(classType.Key, dbcontext)!;
            var instance = (IsEntityExistRepository)instances;
            results.Add(await instance.IsEntityExist(Id));
        }

        if (results.Any(b => b == false))
        {
            context.HttpContext.Response.StatusCode = 404;
            throw new Exception();
        }

        await next();
    }

    public Dictionary<string, object?> Normalizer(IDictionary<string, object?> parameters)
    {
        var normalizedKeys = parameters.Keys.Select(keys => keys[..^2]);
        var values = parameters.Values;

        var mappedDictionary = normalizedKeys.Zip(values, (key, value) => new { value, key })
            .ToDictionary(x => x.key, x => x.value);
        return mappedDictionary;
    }

    public Type? FindTypeByName(string entityName)
    {
        var result = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.IsClass && t.Name.ToLower() == entityName.ToLower());
        return result;
    }
}