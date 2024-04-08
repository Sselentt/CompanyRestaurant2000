using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.AppRoleVM;
using CompanyRestaurant.MVC.Models.AppUserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")] // Yalnızca Admin rolüne sahip kullanıcıların erişimine izin ver.
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleManagerController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new AppRole { Name = model.Name });
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<AppRoleViewModel>(role);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id.ToString());
                if (role == null)
                {
                    return NotFound();
                }

                role.Name = model.Name;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            // Rolü bul
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                // Rol bulunamadıysa, hata döndür
                return NotFound();
            }

            // Rolü sil
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                // Başarılıysa, rollerin listelendiği sayfaya yönlendir
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Silme işlemi başarısız olduysa, hataları ModelState'e ekle
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(role);
            }
        }

        public async Task<IActionResult> UsersInRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound($"Role with ID {roleId} not found.");
            }

            var usersInRole = new List<AppUser>();
            var allUsers = await _userManager.Users.ToListAsync();

            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    usersInRole.Add(user);
                }
            }

            var model = _mapper.Map<IEnumerable<AppUserViewModel>>(usersInRole);
            ViewBag.RoleName = role.Name;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }

            var model = new AssignRoleViewModel { UserId = userId };
            // Tüm rolleri getir ve view model içerisinde kullanıma sun.
            ViewBag.Roles = _roleManager.Roles.ToList().Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId.ToString());
                if (user == null)
                {
                    return NotFound();
                }

                // Önce kullanıcının mevcut rollerini temizle.
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                // Yeni rolleri ata.
                foreach (var roleId in model.RoleIds)
                {
                    var role = await _roleManager.FindByIdAsync(roleId.ToString());
                    if (role != null)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }

                return RedirectToAction(nameof(Index)); // Rol ataması başarılı ise, rollerin listelendiği sayfaya yönlendir.
            }

            // Eğer ModelState geçersizse, formu ve hataları kullanıcıya geri döndür.
            ViewBag.Roles = _roleManager.Roles.ToList().Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            });

            return View(model);
        }


    }
}
