using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.RezervationVM
{
    public class RezervationViewModel
    {
        public int Id { get; set; } // Rezervasyonun benzersiz kimliği

        [Required(ErrorMessage = "Müşteri adı zorunludur.")]
        [Display(Name = "Müşteri Adı")]
        public string Name { get; set; } // Müşteri adı

        [Required(ErrorMessage = "Müşteri soyadı zorunludur.")]
        [Display(Name = "Müşteri Soyadı")]
        public string Surname { get; set; } // Müşteri soyadı

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; } // Müşteri telefon numarası

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; } // Müşteri e-posta adresi

        [Required(ErrorMessage = "Rezervasyon tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Rezervasyon Tarihi")]
        public DateTime ReservationDate { get; set; } // Rezervasyonun yapılacağı tarih

        [Required(ErrorMessage = "Başlangıç saati zorunludur.")]
        [DataType(DataType.Time)]
        [Display(Name = "Başlangıç Saati")]
        public TimeSpan StartTime { get; set; } // Rezervasyonun başlangıç saati

        [Required(ErrorMessage = "Bitiş saati zorunludur.")]
        [DataType(DataType.Time)]
        [Display(Name = "Bitiş Saati")]
        public TimeSpan EndTime { get; set; } // Rezervasyonun bitiş saati

        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Rezervasyonla ilgili ek açıklamalar

        //[Required(ErrorMessage = "Lütfen bir masa seçiniz.")]
        [Display(Name = "Masa")]
        public int? TableId { get; set; } // Rezervasyon yapılan masa numarası (Opsiyonel)

        //// Rezervasyonu yapan kullanıcı bilgisi (Opsiyonel)
        //[Display(Name = "İlgili Çalışan")]
        //public int? AppUserId { get; set; }
        //////[Display(Name = "Rezervasyonu Yapan Kullanıcı")]
        //////public string AppUserName { get; set; } // Rezervasyonu yapan kullanıcının adı

        ////// İlgili müşteri bilgisi (Opsiyonel)
        
        [Display(Name = "Müşteri")]
        public int? CustomerId { get; set; }

        [Display(Name = "İlgili Kişi")]
        public string? AppUserName { get; set; } // İlgili kişi tam adı
        //public SelectList TableList { get; set; }

    }

}
