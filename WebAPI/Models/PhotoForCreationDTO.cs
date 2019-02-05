using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebAPI.Helpers.Concrete;

namespace WebAPI.Models
{
    public class PhotoForCreationDTO
    {
        public int Id { get; set; }
        public string photoUrl { get; set; }
        [Required]
        [ValidateImage]
        public IFormFile File { get; set; }
    }
}
