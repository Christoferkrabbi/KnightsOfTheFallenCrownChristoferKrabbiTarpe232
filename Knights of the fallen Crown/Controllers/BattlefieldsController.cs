using KnightsOfTheFallenCrown.ApplicationServices.Services;
using KnightsOfTheFallenCrown.Core.Dto;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using KnightsOfTheFallenCrown.Models;
using KnightsOfTheFallenCrown.Models.Battlefields;
using KnightsOfTheFallenCrown.Models.Knights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace KnightsOfTheFallenCrown.Controllers
{
	public class BattlefieldsController : Controller
	{
		private readonly KnightsOfTheFallenCrownContext _context;
		private readonly IFileServices _fileServices;
		private readonly IBattlefieldsServices _battlefieldsServices;
		public BattlefieldsController(KnightsOfTheFallenCrownContext context, IBattlefieldsServices battlefieldsServices, IFileServices fileServices)
		{
			_context = context;
			_fileServices = fileServices;
			_battlefieldsServices = battlefieldsServices;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var allBattlefields = _context.Battlefields
				.OrderByDescending(y => y.BattlefieldType)
				.Select(x => new BattlefieldIndexViewModel
				{
					ID = x.ID,
					BattlefieldName = x.BattlefieldName,
					BattlefieldType = x.BattlefieldType,
					EnvironmentBoost = (Models.Knights.KnightTYPE)x.EnvironmentBoost,
					Settlements = x.Settlements,
					TechnicalLevel = x.TechnicalLevel,
					ContinentID = (Guid)x.ContinentID,
					//Image = (List<AstralBodyIndexViewModel>)_context.FilesToDatabase
					//   .Where(t => t.TitanID == x.ID)
					//   .Select(z => new AstralBodyIndexViewModel
					//   {
					//       TitanID = z.ID,
					//       ImageID = z.ID,
					//       ImageData = z.ImageData,
					//       ImageTitle = z.ImageTitle,
					//       Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(z.ImageData))
					//   })
				});
			return View(allBattlefields);
		}

		[HttpGet]
		public IActionResult Create()
		{
			BattlefieldCreateUpdateViewModel vm = new();
			return View("CreateUpdate", vm);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BattlefieldCreateUpdateViewModel vm)
		{
			// this make new, do not add guid
			var dto = new BattlefieldDto()
			{
				BattlefieldName = vm.BattlefieldName,
				BattlefieldType = vm.BattlefieldType,
				EnvironmentBoost = (Core.Dto.KnightTYPE)vm.EnvironmentBoost,
				BattlefieldDescription = vm.BattlefieldDescription,
				Settlements = vm.Settlements,
				TechnicalLevel = vm.TechnicalLevel,
				//no titan owns a planet that has been created by admin
				//and no planet is assigned to a solar system in the planet creation view
				CreatedAt = DateTime.Now,
				ModifiedAt = DateTime.Now,
				Files = vm.Files,
				Image = vm.Image
				.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					BattlefieldID = x.BattlefieldID
				}).ToArray()
			};
			var addedBattlefield = await _battlefieldsServices.Create(dto);
			if (addedBattlefield == null)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", vm);
		}

		[HttpGet]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> Details(Guid id)
		{
			ViewData["RequestedView"] = "Details";
			var dto = await _battlefieldsServices.DetailsAsync(id);

			if (dto == null)
			{
				List<string> errordatas = ["Area", "Planets", "Issue", "var dto == null", "StatusMessage", "This planet was not found"];
				ViewBag.ErrorDatas = errordatas;
				return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}
			var images = await _context.FilesToDatabase
				.Where(x => x.BattlefieldID == id)
				.Select(y => new BattlefieldImageViewModel
				{
					BattlefieldID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();
			var vm = new BattlefieldDetailsDeleteViewModel();

			vm.ID = dto.ID;
			vm.BattlefieldName = dto.BattlefieldName;
			vm.BattlefieldDescription = dto.BattlefieldDescription;
			vm.TechnicalLevel = dto.TechnicalLevel;
			vm.Settlements = dto.Settlements;
			vm.BattlefieldType = dto.BattlefieldType;
			//vm.EnvironmentBoost = dto.EnvironmentBoost;
			vm.ContinentID = dto.ContinentID;
			vm.CreatedAt = dto.CreatedAt;
			vm.ModifiedAt = dto.ModifiedAt;
			vm.Image.AddRange(images);

			return View("DetailsDelete", vm);
		}

		[HttpGet]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> Update(Guid id)
		{
			var battlefieldToBeUpdated = await _battlefieldsServices.DetailsAsync(id);
			if (battlefieldToBeUpdated == null)
			{
				List<string> errordatas = ["Area", "Planets", "Issue", "var battlefieldToBeUpdated == null", "StatusMessage", "Planet with this ID is null"];
				ViewBag.ErrorDatas = errordatas;
				return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}
			var images = await _context.FilesToDatabase
				.Where(x => x.BattlefieldID == id)
				.Select(y => new BattlefieldImageViewModel
				{
					BattlefieldID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();

			var vm = new BattlefieldCreateUpdateViewModel();

			vm.ID = battlefieldToBeUpdated.ID;
			vm.BattlefieldName = battlefieldToBeUpdated.BattlefieldName;
			vm.BattlefieldType = battlefieldToBeUpdated.BattlefieldType;
			vm.EnvironmentBoost = (Models.Knights.KnightTYPE)battlefieldToBeUpdated.EnvironmentBoost;
			vm.BattlefieldDescription = battlefieldToBeUpdated.BattlefieldDescription;
			vm.Settlements = battlefieldToBeUpdated.Settlements;
			vm.TechnicalLevel = battlefieldToBeUpdated.TechnicalLevel;
			vm.LordWhoDominatesThisBattlefield = battlefieldToBeUpdated.LordWhoDominatesThisBattlefield;
			vm.ContinentID = battlefieldToBeUpdated.ContinentID;
			vm.CreatedAt = battlefieldToBeUpdated.CreatedAt;
			vm.ModifiedAt = battlefieldToBeUpdated.ModifiedAt;
			vm.Image.AddRange(images);

			return View("CreateUpdate", vm);
		}

		//for the time being, create and update post methods are separate with only 2
		//differences between them, in the future, these can be combined into one method
		//it is 23:01 and i cant be assed to figure that shit our rn, so this is what you get.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(BattlefieldCreateUpdateViewModel vm)
		{
			// this make new, do not add guid
			var dto = new BattlefieldDto()
			{
				ID = (Guid)vm.ID,
				BattlefieldName = vm.BattlefieldName,
				BattlefieldType = vm.BattlefieldType,
				EnvironmentBoost = (Core.Dto.KnightTYPE)vm.EnvironmentBoost,
				BattlefieldDescription = vm.BattlefieldDescription,
				Settlements = vm.Settlements,
				TechnicalLevel = vm.TechnicalLevel,
				//no titan owns a planet that has been created by admin
				//and no planet is assigned to a solar system in the planet creation view
				CreatedAt = DateTime.Now,
				ModifiedAt = DateTime.Now,
				Files = vm.Files,
				Image = vm.Image
				.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					BattlefieldID = x.BattlefieldID
				}).ToArray()
			};
			var addedPlanet = await _battlefieldsServices.Update(dto);
			if (addedPlanet == null)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", vm);
		}



		[HttpGet]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> Delete(Guid id)
		{
			ViewData["RequestedView"] = "Delete";
			var deletableBattlefield = await _battlefieldsServices.DetailsAsync(id);
			if (deletableBattlefield == null)
			{
				List<string> errordatas = ["Area", "Planets", "Issue", "var deletableAstralBody == null", "StatusMessage", "This planet was not found"];
				ViewBag.ErrorDatas = errordatas;
				return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}
			var images = await _context.FilesToDatabase
				.Where(x => x.BattlefieldID == id)
				.Select(y => new BattlefieldImageViewModel
				{
					BattlefieldID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();
			var vm = new BattlefieldDetailsDeleteViewModel();

			vm.ID = deletableBattlefield.ID;
			vm.BattlefieldName = deletableBattlefield.BattlefieldName;
			vm.BattlefieldDescription = deletableBattlefield.BattlefieldDescription;
			vm.TechnicalLevel = deletableBattlefield.TechnicalLevel;
			vm.Settlements = deletableBattlefield.Settlements;
			vm.BattlefieldType = deletableBattlefield.BattlefieldType;
			vm.EnvironmentBoost = (Models.Knights.KnightTYPE)deletableBattlefield.EnvironmentBoost;
			vm.ContinentID = deletableBattlefield.ContinentID;
			vm.CreatedAt = deletableBattlefield.CreatedAt;
			vm.ModifiedAt = DateTime.Now;
			vm.Image.AddRange(images);

			return View("DetailsDelete", vm);
		}
		[HttpPost]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var battlefieldId = await _battlefieldsServices.Delete(id);
			if (battlefieldId == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction(nameof(Index));
		}

	}
}
