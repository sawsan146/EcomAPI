﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Services
{
    public interface IImageManagementalService
    {

         Task<List<string>> AddImgAsync(IFormFileCollection files, string src);

        void DeleteImgAsync(string src);

      

    }
}
