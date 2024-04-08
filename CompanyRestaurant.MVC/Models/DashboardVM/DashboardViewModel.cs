using CompanyRestaurant.MVC.Models.OrderVM;
using CompanyRestaurant.MVC.Models.PerformanceReviewVM;
using CompanyRestaurant.MVC.Models.ProductVM;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.DashboardVM
{

    public class DashboardViewModel
    {
        [Display(Name = "Toplam Satış")]
        public decimal TotalSales { get; set; } // Toplam satış miktarı

        [Display(Name = "Bugünkü Satışlar")]
        public decimal TodaySales { get; set; } // Bugünkü satış miktarı

        [Display(Name = "Aktif Rezervasyon Sayısı")]
        public int ActiveReservations { get; set; } // Aktif rezervasyonların sayısı

        [Display(Name = "Stokta Azalan Ürün Sayısı")]
        public int LowStockProductsCount { get; set; } // Stok miktarı azalan ürünlerin sayısı

        [Display(Name = "Yeni Müşteriler")]
        public int NewCustomers { get; set; } // Yeni eklenen müşteri sayısı

        [Display(Name = "Toplam Çalışan Sayısı")]
        public int TotalEmployees { get; set; } // Toplam çalışan sayısı

        // Opsiyonel olarak, daha fazla metrik veya bilgi ekleyebilirsiniz
        // Örneğin, son eklenen ürünler, en çok satan ürünler, son siparişler vb.
        public List<ProductViewModel> LatestProducts { get; set; } // Son eklenen ürünler
        public List<OrderViewModel> RecentOrders { get; set; } // En son alınan siparişler
        public List<PerformanceReviewViewModel> LatestPerformanceReviews { get; set; } // Son performans değerlendirmeleri

        public DashboardViewModel()
        {
            LatestProducts = new List<ProductViewModel>();
            RecentOrders = new List<OrderViewModel>();
            LatestPerformanceReviews = new List<PerformanceReviewViewModel>();
        }
    }


}
