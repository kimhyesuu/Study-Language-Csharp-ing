namespace AnimalMatcher.Web.Controllers
{
    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Services.Pet.Interfaces;
    using AnimalMatcher.Web.Models.Pet;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PetController : Controller
    {
        private readonly IPetService petService;
        private readonly UserManager<Owner> userManager;
        private readonly IMapper mapper;

        public PetController(IPetService petService, UserManager<Owner> userManager, IMapper mapper)
        {
            this.petService = petService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult Register()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(PetInputModel pet)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(pet);
            }

            string ownerId = this.userManager.GetUserId(this.User);

            var petToRegister = this.mapper.Map<PetRegisterServiceModel>(pet);
            petToRegister.OwnerId = ownerId;

            this.petService.Register(petToRegister);

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Details(int id)
        {
            var petServiceModel = this.petService.GetById(id);
            var petViewModel = this.mapper.Map<PetDetailedViewModel>(petServiceModel);

            return this.View(petViewModel);
        }
    }
}
