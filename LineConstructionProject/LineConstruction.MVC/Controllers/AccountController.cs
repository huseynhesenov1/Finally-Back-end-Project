using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Utilities;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signinmanager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IEmailService _emailService;


		public AccountController(UserManager<AppUser> usermanager, IMapper mapper, SignInManager<AppUser> signinmanager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
		{
			_usermanager = usermanager;
			_mapper = mapper;
			_signinmanager = signinmanager;
			_roleManager = roleManager;
			_emailService = emailService;
		}


		public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserDTO appUserDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Modelstate Valid deyil");
                return View(appUserDTO);
            }
            if (appUserDTO.Password != appUserDTO.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Password and Confirmpassword are different");
                return View(appUserDTO);
            }
            AppUser appUser = _mapper.Map<AppUser>(appUserDTO);
            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View(appUserDTO);
            }


            var res = await _usermanager.CreateAsync(appUser, appUserDTO.Password);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View(appUserDTO);
            }
			_emailService.SendEmail(appUser.Email);
			string userToken = await _usermanager.GenerateEmailConfirmationTokenAsync(appUser);
			string? url = Url.Action("ConfirmEmail", "Account", new { UserId = appUser.Id, token = userToken }, Request.Scheme);
			_emailService.SendEmailConfirm(appUser.Email, url);
			await _usermanager.AddToRoleAsync(appUser, "Users");
			return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDTO appUserLoginDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Modelstate Valid deyil");
                return View(appUserLoginDTO);
            }

            AppUser? appUser = await _usermanager.FindByNameAsync(appUserLoginDTO.UserName);
            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Not found this Account");
                return View(appUserLoginDTO);
            }
			if (!appUser.EmailConfirmed)
			{
				return BadRequest("please confirm your email");
			}
			var res =   await _signinmanager.PasswordSignInAsync(appUser, appUserLoginDTO.Password, true, true);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View(appUserLoginDTO);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
			{
				return BadRequest("Invalid email confirmation request.");
			}

			var user = await _usermanager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound("User not found.");
			}

			if (user.EmailConfirmed)
			{
				return RedirectToAction("Login");
			}

			var result = await _usermanager.ConfirmEmailAsync(user, token);
			if (result.Succeeded)
			{
				return RedirectToAction("Login");
			}

			return BadRequest("Email confirmation failed. Please check your confirmation link.");
		}
		public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Modelstate Valid deyil");
                return View(changePasswordDTO);
            }
            if (changePasswordDTO.ConfirmPassword != changePasswordDTO.NewPassword)
            {
                ModelState.AddModelError(string.Empty, "ConfirmPassword ile New Password eyni olmalidir");
                return View(changePasswordDTO);
            }
            AppUser?  user=  await _usermanager.FindByNameAsync(changePasswordDTO.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Hesab tapilmadi");
                return View(changePasswordDTO);
            }
            var res = await _usermanager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Hesab tapilmadi");
                return View(changePasswordDTO);
            }
            return RedirectToAction("Login");
        }

        //public async Task CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Users" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "HR" });
        //}

        //public async Task CreateAdmin()
        //{
        //    AppUser appUser = new AppUser();
        //    appUser.FirstName = "Hesenov Huseyn";
        //    appUser.LastName = "HuseynAdmin";
        //    appUser.UserName = "Admin";
        //    appUser.Email = "Admin12@com";
        //    await _usermanager.CreateAsync(appUser, "Admin123!");
        //    await _usermanager.AddToRoleAsync(appUser, "Admin");
        //}

        //public async Task CreateHR()
        //{
        //    AppUser appUser = new AppUser();
        //    appUser.FirstName = "Hesenov Huseyn";
        //    appUser.LastName = "HuseynHR";
        //    appUser.UserName = "HR";
        //    appUser.Email = "HR1245@com";
        //    await _usermanager.CreateAsync(appUser, "Hr12345!");
        //    await _usermanager.AddToRoleAsync(appUser, "HR");
        //}
    }
}
