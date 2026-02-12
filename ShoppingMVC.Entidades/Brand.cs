using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMVC.Entidades
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();

    }
}
