using KnightsOfTheFallenCrown.Core.Domain;
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
            var resultingInventory = _context.Knight
            .OrderByDescending(y => y.Level)
            .Select(x => new KnightsIndexViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Level = x.Level,    
                KnightType= (KnightTYPE)x.KnightType,
            });
            return View(resultingInventory);
        }
    }
}

