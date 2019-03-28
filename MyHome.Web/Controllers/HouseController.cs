using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHome.Domain;
using MyHome.Infrastructure;
using MyHome.Web.Models.House;

namespace MyHome.Web.Controllers
{
    public class HouseController : Controller
    {
        #region Private attributes
        private readonly MyHomeDbContext dbContext = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="dbContext">Contexte de la base de données (l'instance nous sera transmise par injection)</param>
        public HouseController(MyHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        public IActionResult Index()
        {
            // Sélection des maisons à afficher depuis la BDD
            // SELECT * FROM House 
            var houses = dbContext.Set<House>().ToList();

            // Remplissage du viewmodel avec le résultat de la requête précédente
            var vm = new ListHousesViewModel();
            vm.Houses.AddRange(houses);

            return View(vm);
        }

        [HttpGet] // facultatif car implicite
        public IActionResult Create()
        {
            // Retourne la vue (Create) avec une instance de CreateHouseViewModel afin de pouvoir l'utiliser sur la vue
            return View(new CreateHouseViewModel());
        }

        [HttpPost] 
        public IActionResult Create(CreateHouseViewModel vm)
        {
            // Sécurité : permet de s'assurer de la bonne saisie du formulaire par l'utilisateur
            if(ModelState.IsValid)
            {
                // Recherche d'une maison qui porte le même nom
                var existingHouse = dbContext
                    .Set<House>() // Equivalent SELECT * FROM House
                    .Where(x => x.Name == vm.Name) // Clause Where (équivalent where SQL)
                    .SingleOrDefault(); // 1 seul enregistrement ou null

                if (existingHouse == null)
                {
                    // Insertion de la maison en BDD
                    var newHouse = new House { Name = vm.Name };
                    dbContext.Add(newHouse); // Ajout de l'entité au contexte de données, il prends un Id temporaire
                    dbContext.SaveChanges(); // Application des changements en BDD (insert réel)

                    ViewBag.Success = $"La maison {vm.Name} a été créée avec succès";
                }
                else
                {
                    // On indique à l'utilisateur que la maison existe déjà, ViewBag == ViewData
                    ViewBag.Error = $"Une maison existe déjà pour le nom {vm.Name}";
                }
            }

            return View(vm);
        }

        /// <summary>
        /// Action de mise à jour de la fiche maison
        /// </summary>
        /// <param name="id">Identifiant de la maison à charger pour MAJ</param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            // TODO ... Have fun!
            return View();

        }

    }
}