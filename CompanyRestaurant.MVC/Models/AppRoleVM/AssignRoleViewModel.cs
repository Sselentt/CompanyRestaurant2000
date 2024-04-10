using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.AppRoleVM
{
    public class AssignRoleViewModel
    {
        public int RoleId { get; set; } // Kullanıcının benzersiz ID'si
        public string Name { get; set; }
        public bool Exists { get; set; }

        //[Required(ErrorMessage = "En az bir rol seçilmelidir.")]
        //[Display(Name = "Roller")]
        //public List<int> RoleId { get; set; } // Atanacak rollerin ID'leri

        //public AssignRoleViewModel()
        //{
        //    RoleId = new List<int>();
        //}
    }
}
