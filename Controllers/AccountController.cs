using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SwitchPlayD.Identity.IdentityService;
using SwitchPlayD.Identity;
using SwitchPlayD.Data;
using SwitchPlayD.Models.AccountViewModels;

namespace SwitchPlayD.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IRoleService _roleService;

        public AccountController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ILogger<AccountController> logger, IRoleService roleService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleService = roleService;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewBag.Error = false;
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true 
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                var isAuthenticated = User.Identity.IsAuthenticated;
                return RedirectToAction("Index", "Home", new { authenticated = isAuthenticated });
            }
            //if (result.RequiresTwoFactor)
            //{
            //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
            //}
            // if (result.IsLockedOut)
            // {
            //     _logger.LogWarning("User account locked out.");
            //     return RedirectToAction(nameof(Lockout));
            // }
            else
            {
                ViewBag.Error = true;
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // If we got this far, something failed, redisplay form
        }


        // [HttpGet]
        // [AllowAnonymous]
        // public IActionResult Lockout()
        // {
        //     return View();
        // }

        //[HttpGet]
        //[AllowAnonymous]

        ////[Breadcrumb("Add User", CacheTitle = true, FromAction = "Users.Index")]
        //public IActionResult Register(string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    ViewBag.LastElement = "Add User";
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    var user = new AppUser
        //    {
        //        UserName = model.Email,
        //        Email = model.Email,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName
        //    };

        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (result.Succeeded)
        //    {
        //        var userRole = new AppUserRole
        //        {
        //            RoleId = "moderatorId",
        //            UserId = user.Id
        //        };
        //        await _context.AddAsync(userRole);
        //        await _context.SaveChangesAsync();
        //        _logger.LogInformation("User created a new account with password.");
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            TempData["message"] = $"User {model.Email} added successfully!";
        //            return RedirectToAction("Index", "User");
        //        }
        //        else
        //        {
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            _logger.LogInformation("User created a new account with password.");
        //            return RedirectToLocal(returnUrl);
        //        }

        //    }
        //    AddErrors(result);

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        // [HttpGet]
        // [AllowAnonymous]
        // public IActionResult ResetPasswordConfirmation()
        // {
        //     return View();
        // }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}
