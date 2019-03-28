using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHome.Infrastructure;
using MyHome.Web.Models.Register;

namespace MyHome.Web.Controllers
{
    public class RegisterController : Controller
    {
        #region Private attributes

        private readonly MyHomeDbContext dbContext = null;
        #endregion
        
        /// <summary>
        /// Constructeur du controller
        /// </summary>
        /// <param name="myHomeDbContext">Contexte contenant la liaison avec la base de données</param>
        public RegisterController(MyHomeDbContext myHomeDbContext)
        {
            this.dbContext = myHomeDbContext;
        }

        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        public IActionResult Save(RegisterViewModel vm)
        {
            if(ModelState.IsValid)
            {
                // Traitement si la saisie utilisateur est valide
                // TODO : implémenter la sauvegarde
                Domain.User newUser = new Domain.User()
                {
                    Email = vm.Email,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Password = vm.Password
                };

                // Ajoute le nouvel objet au contexte de la base de données
                this.dbContext.Add(newUser);
                // Sauvegarde les modifications
                this.dbContext.SaveChanges();
            }
            else
            {
                // Traitement si la saisie utilisateur est invalide
            }
        

                //if(string.IsNullOrEmpty(vm.Email))
                //{
                //    ViewData["error"] = "L'email est obligatoire";
                //}

                //if (string.IsNullOrEmpty(vm.FirstName))
                //{
                //    ViewData["error"] = ViewData["error"] + " Le prénom est obligatoire";
                //}

                
                return View();
        }
    }
}