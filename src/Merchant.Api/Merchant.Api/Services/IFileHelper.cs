using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Services;

public interface IFileHelper
{
    Task<string> SaveFileAsync(IFormFile file, EFileType fileType, EFileFolder fileFolder);
}
