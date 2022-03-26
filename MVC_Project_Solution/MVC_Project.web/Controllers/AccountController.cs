using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Core.Helper;
using MVC_Project.Core.Models;
using System;
using System.Threading.Tasks;

namespace Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;


        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        #region Registration(Sign up)

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser()
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        IsAgree = model.IsAgree
                    };

                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                       
                        CookieOptions cookieOptions = new CookieOptions();
                        cookieOptions.Expires = System.DateTimeOffset.Now.AddDays(10);
                        Response.Cookies.Append("CustomerId", user.Id, cookieOptions);
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("DisplayMenu", "CustomerMenu");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                }


                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);

            }
        }
       [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AdminRegistration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminRegistration(RegistrationVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser()
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        IsAgree = model.IsAgree
                    };

                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        // create Role
                         await userManager.AddToRoleAsync(user, "Admin");
                        //create cookies
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Dashboard", "Menu");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                }


                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);

            }
        }



        #endregion


        #region Login(Sign in)

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var user = await userManager.FindByNameAsync(model.Email);
                        
                        if (await userManager.IsInRoleAsync(user,"Admin"))
                        {
                            return RedirectToAction("Dashboard", "Menu");
                        }
                        else
                        {
                            CookieOptions cookieOptions = new CookieOptions();
                            cookieOptions.Expires = System.DateTimeOffset.Now.AddDays(10);
                            Response.Cookies.Append("CustomerId", user.Id, cookieOptions);
                            return RedirectToAction("DisplayMenu", "CustomerMenu");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invaild username or password");
                    }

                }
                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);

            }
        }
        



        #endregion


        #region Log off(Sign out)

        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }





        #endregion


        #region Forget Password

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //get user by mail 
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (User != null)
                    {
                        //if user exists generate token
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        //Generate reset link
                        var PasswordResetLink = Url.Action("ResetPassword", "Account",
                                                new { Email = model.Email, Token = token }, Request.Scheme);

                        //Send Mail
                        MailSender.SendMail(new MailVM()
                        {
                            Title = "Feane - Reset Password",
                            Message = PasswordResetLink,
                            Email = model.Email
                        });

                        return RedirectToAction("ConfirmForgetPassword");
                    }
                }

                return RedirectToAction("ConfirmForgetPassword");

            }
            catch (Exception ex)
            {

                return View(model);

            }
        }




        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }


        #endregion


        #region Reset Password

        [HttpGet]
        public IActionResult ResetPassword(string Email, string Token)
        {
            if (Email != "" && Token != "")
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    }

                }
                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);

            }
        }



        [HttpGet]
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

        #endregion



    }
}
