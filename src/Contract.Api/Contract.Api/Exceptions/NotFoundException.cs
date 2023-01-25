using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Contract.Api.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {

    }
}

public class NotFoundException<T> : NotFoundException 
{
    public NotFoundException() : base ($"{typeof (T).Name}is not found")
    {

    }
}