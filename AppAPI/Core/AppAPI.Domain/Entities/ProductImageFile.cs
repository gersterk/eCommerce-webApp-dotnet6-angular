using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Domain.Entities
{
    public class ProductImageFile : File
    {
        public Product Product { get; set; }
    }
}
