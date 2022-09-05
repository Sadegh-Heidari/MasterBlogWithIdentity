using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace MasterIdentity.Utility
{
    public static class ConvertImage
    {
        public static async Task<string> Excute(IFormFile ImageFile, string WebRootPath)
        {

            var rootpath = Path.Combine(WebRootPath, "img", ImageFile.FileName);
            if (!System.IO.File.Exists(rootpath))
            {
                using (var fi = new FileStream(rootpath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fi).ConfigureAwait(false);
                }

                return ImageFile.FileName;
            }

            return ImageFile.FileName;
        }
    }
}
