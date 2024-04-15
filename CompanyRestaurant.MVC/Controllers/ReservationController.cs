using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.RezervationVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Controllers
{

    public class ReservationController : Controller
    {
        private readonly IRezervationRepository _rezervationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public ReservationController(IRezervationRepository rezervationRepository, ITableRepository tableRepository, IMapper mapper)
        {
            _rezervationRepository = rezervationRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        // Rezervasyon Formunu Göster
        public async Task<IActionResult> Create()
        {
            // Tüm masaları getir
            var tables = await _tableRepository.GetAllTables();
            var model = new RezervationViewModel
            {
                // "TableNo" masanın görüntülenecek değeridir, bu örnekte masanın numarası
              //  TableList = new SelectList(tables, "Id", "TableNo")
            };
            return View(model);
        }

        // Rezervasyon Yap
        [HttpPost]
        public async Task<IActionResult> Create(RezervationViewModel model)
        {
            if (ModelState.IsValid)
            {
                //// Müşterinin adı ve soyadını ayırma
                //var userNameParts = model.AppUserName.Split(' ');
                //var name = userNameParts[0];
                //var surname = userNameParts[1];

                //// Modeli güncelle
                //model.Name = name;
                //model.Surname = surname;

                // AutoMapper kullanarak rezervasyon nesnesine dönüştür
                var reservation = _mapper.Map<Rezervation>(model);
                await _rezervationRepository.MakeReservation(reservation);

                // Rezervasyon başarılı ise ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }

            return View(model);
            
        }
    }
}
