using KnightsOfTheFallenCrown.Core.Dto;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using KnightsOfTheFallenCrown.Models.Knights;
using Microsoft.AspNetCore.Mvc;

namespace KnightsOfTheFallenCrown.Controllers
{
    public class KnightsController : Controller
    {
        private readonly KnightsOfTheFallenCrownContext _context;
        private readonly IKnightsServices _KnightsServices;
        public KnightsController(KnightsOfTheFallenCrownContext context, IKnightsServices knightsServices)
        {
            _context = context;
            _KnightsServices = knightsServices;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var resultingInventory = _context.Knights
            .OrderByDescending(y => y.KnightLevel)
            .Select(x => new KnightsIndexViewModel
            {
                KnightID = x.ID,
                KnightName = x.KnightName,
                KnightLevel = x.KnightLevel,    
                KnightType= (Models.Knights.KnightTYPE)(Core.Dto.KnightTYPE)x.KnightType,
            });
            return View(resultingInventory);
        }
    }
}

