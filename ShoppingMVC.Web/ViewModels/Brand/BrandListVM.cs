using System.ComponentModel;

namespace ShoppingMVC.Web.ViewModels.Brand
{
    public class BrandListVM
    {
        public int BrandId { get; set; }

        [DisplayName("Marcas")]
        public string BrandName { get; set; }

    }
}
