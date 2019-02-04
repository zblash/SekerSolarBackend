using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Photo:IEntity
    {
        public int Id { get; set; }
        public string photoUrl { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
