using KnightsOfTheFallenCrown.Models.Knights;
using KnightsOfTheFallenCrown.Core.Dto;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnightsOfTheFallenCrown.Controllers
{
	public class KnightsController : Controller
    {
        private readonly KnightsOfTheFallenCrownContext _context;
        private readonly IKnightsServices _knightsServices;
        private readonly IFileServices _fileServices;


        public KnightsController(KnightsOfTheFallenCrownContext context, IKnightsServices knightsServices, IFileServices fileServices)
        {
            _context = context;
            _knightsServices = knightsServices;
            _fileServices = fileServices;
        }

        [HttpGet]
        public  IActionResult Index()
        {
            var resultingInventory = _context.Knights
            .OrderByDescending(y => y.KnightLevel)
            .Select(x => new KnightsIndexViewModel
            {
                ID = x.ID,
                KnightName = x.KnightName,
                KnightLevel = x.KnightLevel,    
                KnightType= (Models.Knights.KnightTYPE)(Core.Dto.KnightTYPE)x.KnightType,
            });
            return View(resultingInventory);          
        }

        [HttpGet]
        public IActionResult Create()
        {
            KnightCreateViewModel vm = new();
            return View("Create", vm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KnightCreateViewModel vm)
        {
            var dto = new KnightDto()
            {
                KnightName = vm.KnightName,
                KnightHealth = 100,
                KnightXP = 0,
                KnightXPNextLevel = 100,
                KnightLevel = 0,
                KnightType = (Core.Dto.KnightTYPE)vm.KnightType,
                KnightStatus = (Core.Dto.KnightStatus)vm.KnightStatus,
				PrimaryAttackName = vm.PrimaryAttackName,
				PrimaryAttackPower = vm.PrimaryAttackPower,
				SecondaryAttackName = vm.SecondaryAttackName,
				SecondaryAttackPower = vm.SecondaryAttackPower,


				CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    KnightID = x.KnightID,
                }).ToArray()
            };
            var result = await _knightsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var knight = await _knightsServices.DetailsAsync(id);

            if (knight == null)
            {
                return NotFound(); // <- TODO; custom partial view with message, titan is not located
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.KnightID == id)
                .Select(y => new KnightImageViewModel
                {
                    KnightID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new KnightDetailsViewModel();
            vm.ID = knight.ID;
            vm.KnightName = knight.KnightName;
            vm.KnightHealth = knight.KnightHealth;
            vm.KnightXP = knight.KnightXP;
            vm.KnightLevel = knight.KnightLevel;
            vm.KnightType = (Models.Knights.KnightTYPE)knight.KnightType;
            vm.KnightStatus = (Models.Knights.KnightStatus)knight.KnightStatus;
          //  vm.Image.AddRange(images);//<--FileToDatabase

            return View(vm);
        }

        [HttpGet]
        public async Task <IActionResult> Update(Guid id)
        {
            if(id == null){return NotFound(); }
            var knight = await _knightsServices.DetailsAsync(id);
            if(knight == null) { return NotFound(); }
            var images = await _context.FilesToDatabase
                .Where(x=> x.KnightID == id)
              .Select(y => new KnightImageViewModel
              {
                  KnightID = y.ID,
                  ImageID = y.ID,
                  ImageData = y.ImageData,
                  ImageTitle = y.ImageTitle,
                  Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
              }).ToArrayAsync();
            var vm = new KnightCreateViewModel();
            vm.ID = knight.ID;
            vm.KnightName = knight.KnightName;
            vm.KnightHealth = knight.KnightHealth;
            vm.KnightXP = knight.KnightXP;
            vm.KnightLevel = knight.KnightLevel;
            vm.KnightType = (Models.Knights.KnightTYPE)knight.KnightType;
            vm.KnightStatus = (Models.Knights.KnightStatus)knight.KnightStatus;
            vm.Image.AddRange(images);

            return View("Update", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KnightCreateViewModel vm)
        {
            var dto = new KnightDto()
            {
                ID = (Guid)vm.ID,
                KnightName = vm.KnightName,
                KnightHealth = 100,
                KnightXP = 0,
                KnightXPNextLevel = 100,
                KnightLevel = 0,
                KnightType = (Core.Dto.KnightTYPE)vm.KnightType,
                KnightStatus = (Core.Dto.KnightStatus)vm.KnightStatus,
                

                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    KnightID = x.KnightID,
                }).ToArray()

            };
            var result = await _knightsServices.Update(dto);

            if(result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var knight = await _knightsServices.DetailsAsync(id);

            if (knight == null) { return NotFound(); };

            var images = await _context.FilesToDatabase
                .Where(x => x.KnightID == id)
                .Select(y => new KnightImageViewModel
                {
                    KnightID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new KnightDeleteViewModel();

            vm.ID = knight.ID;
            vm.KnightName = knight.KnightName;
            vm.KnightHealth = knight.KnightHealth;
            vm.KnightXP = knight.KnightXP;
            vm.KnightXPNextLevel = knight.KnightXPNextLevel;
            vm.KnightLevel = knight.KnightLevel;
            vm.KnightType = (Models.Knights.KnightTYPE)knight.KnightType;
            vm.KnightStatus = (Models.Knights.KnightStatus)knight.KnightStatus;
            vm.PrimaryAttackName = knight.PrimaryAttackName;
            vm.PrimaryAttackPower = knight.PrimaryAttackPower;
            vm.SecondaryAttackName = knight.SecondaryAttackName;
            vm.SecondaryAttackPower = knight.SecondaryAttackPower;
            vm.CreatedAt = knight.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var knightToDelete = await _knightsServices.Delete(id);

            if (knightToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(KnightImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = vm.ImageID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
    }
}


