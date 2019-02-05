using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public Product()
        {
            Photos = new List<Photo>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
        public List<Photo> Photos { get; set; }


    }
}
