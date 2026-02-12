using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMVC.Web.ViewModels.Brand
{
    public class BrandEditVM
    {
        public int BrandId { get; set; }

        [Required(ErrorMessage ="{0} campo requerido")]
        [StringLength(200, ErrorMessage ="{0} debe contener entre{2} y {1} caracteres", MinimumLength=3)]
        [DisplayName("Marcas")]

        public string BrandName { get; set; }


    }
}
