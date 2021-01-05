using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeboncoin.Services
{
    public interface IUpload
    {
        string Upload(IFormFile image);
    }
}
