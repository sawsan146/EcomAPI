using Ecom.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository.Services
{
    public class ImageManagementalService : IImageManagementalService
    {

        private readonly IFileProvider fileProvider;
        public ImageManagementalService(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImgAsync(IFormFileCollection files, string src)
        {
            var SaveImagesSrc=new List<string>();

            var imgDirectory = Path.Combine("wwwroot", "Images", src);

            if (Directory.Exists(imgDirectory) is not true)
            {
                Directory.CreateDirectory(imgDirectory);
            }

            foreach (var file in files)
            {
                if(file.Length > 0)
                {
                    var imgName=file.FileName;
                    var imgPath= Path.Combine(imgDirectory, imgName);

                    var root=Path.Combine(imgDirectory, imgName);

                    using(FileStream stream=new FileStream(root, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    SaveImagesSrc.Add(Path.Combine("Images",src, imgName));
                }


            }
            return SaveImagesSrc;



        }

        public void DeleteImgAsync(string src)
        {

            var info=fileProvider.GetFileInfo(src);

            var path=info.PhysicalPath;

            File.Delete(path);

        }
    }
}
