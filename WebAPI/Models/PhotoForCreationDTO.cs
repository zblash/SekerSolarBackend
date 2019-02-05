using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Models
{
    public class PhotoForCreationDTO
    {
        public int Id { get; set; }
        public string photoUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
