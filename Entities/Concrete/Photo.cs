using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Photo:IEntity
    {
        public int Id { get; set; }
        [Required]
        public string photoUrl { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
