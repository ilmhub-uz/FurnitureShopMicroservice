using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Services;

public class FileHelper : IFileHelper
{
    public async Task<string> SaveFileAsync(IFormFile file, EFileType fileType, EFileFolder fileFolder)
    {
        var path = Path.Combine("wwwroot", fileType.ToString(), fileFolder.ToString());
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string filePathName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);

        var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        await System.IO.File.WriteAllBytesAsync(Path.Combine(path, filePathName), ms.ToArray());

        return filePathName;
    }
}
