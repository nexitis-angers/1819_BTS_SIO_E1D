using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyHome.Domain;
using MyHome.Infrastructure;
using MyHome.Web.Models.Account;

namespace MyHome.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyHomeDbContext dbContext = null;

        public AccountController(MyHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Retourne la vue de connexion
        /// </summary>
        /// <param name="returnUrl">Ce paramètre permet de rediriger l'utilisateur vers la page auquel il souhaitait accéder avant d'être redirigé vers la page de connexion</param>
        /// <returns></returns>
        public IActionResult Login(string returnUrl)
        {
            if(!string.IsNullOrEmpty(returnUrl) 
                && Url.IsLocalUrl(returnUrl)) // On vérifie que la redirection concerne bien une url locale au site web pour éviter toute redirection vers un site externe, il s'agit d'une protection contre le phishing)
            {
                return Redirect(returnUrl);
            }

            return View(new LoginViewModel()); // Redirection vers la vue de connexion
        }


        /// <summary>
        /// Action de connexion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var existingUser = dbContext
                    .Set<User>() // Equivalent SELECT * FROM User
                    .Where(x => x.Email == loginViewModel.Email
                             && x.Password == loginViewModel.Password)
                     .SingleOrDefault();

                if (existingUser == null)
                {
                    ViewBag.Error = "Aucun compte n'a été trouvé pour les identifiants donnés";
                    return View(loginViewModel); // Redirection vers la vue de connexion avec les données saisies par l'utilisateur
                }
                else
                {
                    // Les claims sont les revendications de l'utilisateur sur l'application, ainsi on peut stocker des données sur l'utilisateur tels que son nom, prénom, rôle au sein de l'application, ...
                    var claims = new List<Claim>()
                    {
                        // On stockera dans les informations de la session de l'utilisateur, son nom, son Id et son rôle
                        new Claim(ClaimTypes.Name, $"{existingUser.FirstName} {existingUser.Email}"),
                        new Claim(ClaimTypes.Role, $"Administrator"),
                        new Claim(ClaimTypes.PrimarySid, existingUser.Id.ToString())
                    };

                    // Un cookie est petit fichier texte qui est attaché au navigateur de l'utilisateur qui permet de stocker de l'information concernant l'utilisateur
                    // Son nom, son email, son id, ses préférences utilisateurs, ...
                    // On stockera les revendications de l'utilisateurs, dans un cookie
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties()
                    {
                        AllowRefresh = true, // On indique que la session doit-être raffraichie au moment de l'expiration
                        ExpiresUtc = DateTime.Now.AddHours(6), // On indique que la session durera 1h
                        IsPersistent = loginViewModel.StayConnected // On indique que l'utilisateur pourra faire persister sa session
                    };

                    // Ecriture du cookie
                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                }

                return RedirectToAction("Index", "House"); // Redirection vers la liste des maisons
            }
            else
                return View(loginViewModel); // Redirection vers la vue de connexion avec les données saisies par l'utilisateur

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Déconnexion

            return RedirectToAction("Login", "Account"); // Redirection vers la page de connexion
        }
    }
}