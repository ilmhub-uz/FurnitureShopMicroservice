using Microsoft.AspNetCore.Mvc;

namespace Contract.Api.Filters;

public class IdValidationAttribute : TypeFilterAttribute
{
    public IdValidationAttribute() : base(typeof(IsIdExistsAttribute)) { }
}