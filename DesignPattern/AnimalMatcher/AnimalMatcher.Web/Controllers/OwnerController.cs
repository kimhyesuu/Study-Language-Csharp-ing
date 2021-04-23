namespace AnimalMatcher.Web.Controllers
{
    using System.Linq;

    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Services.Owner.Interfaces;
    using AnimalMatcher.Services.Pet.Interfaces;
    using AnimalMatcher.Web.Models.Owner;
    using AnimalMatcher.Web.Models.Pet;

    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OwnerController : Controller
    {
        private readonly IPetService petService;
        private readonly IOwnerService ownerService;
        private readonly UserManager<Owner> userManager;
        private readonly IMapper mapper;
        
        public OwnerController(IPetService petService, IOwnerService ownerService, UserManager<Owner> userManager, IMapper mapper)
        {
            this.petService = petService;
            this.ownerService = ownerService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult MyPets()
        {
            string ownerId = this.userManager.GetUserId(this.User);
            var petsByOwner = this.petService
                .GetOwnersPets(ownerId)
                .Select(petServiceModel => this.mapper.Map<PetShortViewModel>(petServiceModel));

            return this.View(petsByOwner);
        }
        
        public IActionResult Details(string id)
        {
            var ownerWithPets = this.ownerService.GetOwnerWithPetsById(id);
            var ownerWithPetsViewModel = this.mapper.Map<OwnerViewModel>(ownerWithPets);

            return this.View(ownerWithPetsViewModel);
        }
    }
}
