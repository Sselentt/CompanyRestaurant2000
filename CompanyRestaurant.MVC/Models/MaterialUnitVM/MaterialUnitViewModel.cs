using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.MaterialUnitVM
{
    public class MaterialUnitViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Birim alanı zorunludur.")]
        [Display(Name = "Birim")]
        public string Unit { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Malzeme ID alanı zorunludur.")]
        [Display(Name = "Malzeme ID")]
        public int MaterialId { get; set; }
    }
}
