using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.AppRoleVM;
using CompanyRestaurant.MVC.Models.AppUserVM;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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


        public async Task<IActionResult> UserRoleList()
        {
            var roleList=_userManager.Users.ToList();
            return View(roleList);
        }


        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);


            List<AssignRoleViewModel> model = new List<AssignRoleViewModel>();
            foreach (var item in roles)
            {
                AssignRoleViewModel m = new AssignRoleViewModel();
                m.RoleId = item.Id;
                m.Name = item.Name;
                m.Exists = userRoles.Contains(item.Name);
                model.Add(m);
            }
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> model)
        {
            var userid =(int)TempData["UserId"];
            var user=_userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if(item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);

                }
            }
            return RedirectToAction("UserRoleList");
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
    }
}
