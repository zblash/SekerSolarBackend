using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
