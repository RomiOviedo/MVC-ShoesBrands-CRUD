using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMVC.Web.ViewModels.Shoe
{
    public class ShoeEditVM
    {
        public int ShoeId { get; set; }


        [Required(ErrorMessage = "ShoeName is Required")]
        public string ShoeName { get; set; } = null!;


        [Required(ErrorMessage = "Brand is Required")]
        [DisplayName("Brand")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Brand")] // must:debe| maxvalue= valor de ids , no cantidad de marcas seleccionadas
        public string? BrandId { get; set; }



        [DisplayName("Price")]
        public decimal Price { get; set; }



        [ValidateNever]
        public IEnumerable<SelectListItem> Brands { get; set; } = null!;

    }
}
