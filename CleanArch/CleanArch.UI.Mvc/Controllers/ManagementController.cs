namespace Keian.Web.Controllers
{
    using CleanArch.Application;
    using CleanArch.Application.ViewModels;
    using CleanArch.Application.ViewModels.Base;
    using CleanArch.Domain.Auth;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ManagementController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IModelFactory _modelFactory;

        public ManagementController(ILoggerManager logger,
                                 RoleManager<ApplicationRole> roleManager,
                                 UserManager<ApplicationUser> userManager,
                                 IModelFactory modelFactory)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _modelFactory = modelFactory;
        }

        public IActionResult RoleIndex()
        {
            var roles = _roleManager.Roles;
            var result = roles.Select(_modelFactory.Create);
            return View(result);
        }

        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreateAsync(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole()
                {
                    Name = model.Name,
                    PersianName = model.PersianName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Management");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RoleEditAsync(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"نقشی با شناسه {Id} یافت نشد";
                return NotFound();
            }
            var model = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                PersianName = role.PersianName
            };
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    model.Users.Add(user.UserName);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleEditAsync(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existRole = await _roleManager.FindByIdAsync(model.Id.ToString());
                if (existRole == null)
                {
                    ViewBag.ErrorMessage = $"نقشی با شناسه {model.Id} یافت نشد";
                    return NotFound();
                }

                existRole.Name = model.Name;
                existRole.PersianName = model.PersianName;

                var result = await _roleManager.UpdateAsync(existRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleIndex", "Management");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"نقشی با شناسه {roleId} یافت نشد";
                return NotFound();
            }
            var model = new List<UserRoleViewModel>();
            foreach (var user in _userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id.ToString(),
                    UserName = user.UserName
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userRoleViewModel.IsSelected = true;
                else
                    userRoleViewModel.IsSelected = false;
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"نقشی با شناسه {roleId} یافت نشد";
                return NotFound();
            }
            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("RoleEdit", new { Id = roleId });
                }
            }
            return RedirectToAction("RoleEdit", new { Id = roleId });
        }
    }
}
