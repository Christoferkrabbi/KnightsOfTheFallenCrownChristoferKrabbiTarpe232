using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace KnightsOfTheFallenCrown.ApplicationServices.Services
{
	public class BattlefieldsServices : IBattlefieldsServices
	{

		private readonly KnightsOfTheFallenCrownContext _context;
		private readonly IFileServices _fileServices;

		public BattlefieldsServices(KnightsOfTheFallenCrownContext context, IFileServices fileServices)
		{
			_context = context;
			_fileServices = fileServices;
		}
		public async Task<Battlefield> DetailsAsync(Guid id)
		{
			var result = await _context.Battlefields
				.FirstOrDefaultAsync(x => x.ID == id);
			return result;
		}

		public async Task<Battlefield> Create(BattlefieldDto dto)
		{
			Random RNG = new Random(); // make a random rng 
			int settlementcount; //make variable called settlementcount, it is of type int
			if (dto.Settlements == null) //iif user has not input a settlementcount
			{ settlementcount = RNG.Next(1, 200); } //it will be randomly generated
			else { settlementcount = dto.Settlements; } //otherwise, settlementcount is what it is

			Battlefield newBattlefield = new();

			// set by service on first creation
			newBattlefield.ID = Guid.NewGuid();
			newBattlefield.Settlements = settlementcount;
			if (settlementcount >= 189)
			{ newBattlefield.TechnicalLevel = KardashevScale.Type3; }
			else if (190 >= settlementcount && settlementcount >= 150)
			{ newBattlefield.TechnicalLevel = KardashevScale.Type2; }
			else { newBattlefield.TechnicalLevel = KardashevScale.Type1; }
			//no knight/lord owns a battlefield that has been created by admin
			

			// set by admin
			newBattlefield.BattlefieldName = dto.BattlefieldName;
			newBattlefield.BattlefieldType = dto.BattlefieldType;
			newBattlefield.EnvironmentBoost = (Core.Domain.KnightTYPE)dto.EnvironmentBoost;
			newBattlefield.BattlefieldDescription = dto.BattlefieldDescription;

			// set for db
			newBattlefield.CreatedAt = DateTime.Now;
			newBattlefield.ModifiedAt = DateTime.Now;

			if (dto.Files != null)
			{
				_fileServices.UploadFilesToDatabase(dto, newBattlefield, dto.BattlefieldType);
				
			}

			await _context.Battlefields.AddAsync(newBattlefield);
			await _context.SaveChangesAsync();
			return newBattlefield;
		}

		public async Task<Battlefield> Update(BattlefieldDto dto)
		{
			Battlefield BattlefieldChanged = new();

			BattlefieldChanged.ID = dto.ID;
			BattlefieldChanged.BattlefieldName = dto.BattlefieldName;
			BattlefieldChanged.BattlefieldType = dto.BattlefieldType;
			BattlefieldChanged.EnvironmentBoost = (Core.Domain.KnightTYPE)dto.EnvironmentBoost;
			BattlefieldChanged.BattlefieldDescription = dto.BattlefieldDescription;
			BattlefieldChanged.Settlements = dto.Settlements;
			BattlefieldChanged.TechnicalLevel = dto.TechnicalLevel;
			//BattlefieldChanged.LordWhoDominatesThisBattlefield = dto.LordWhoDominatesThisBattlefield;
			BattlefieldChanged.ContinentID = dto.ContinentID;
			BattlefieldChanged.CreatedAt = dto.CreatedAt;
			BattlefieldChanged.ModifiedAt = DateTime.Now;

			if (dto.Files != null)
			{
				await _fileServices.UploadFilesToDatabase(dto, BattlefieldChanged, dto.BattlefieldType);
			}

			_context.Battlefields.Update(BattlefieldChanged);
			await _context.SaveChangesAsync();
			return BattlefieldChanged;

		}

		public async Task<Battlefield> Delete(Guid id)
		{
			var result = await _context.Battlefields.FirstOrDefaultAsync(x => x.ID == id);
			_context.Battlefields.Remove(result);
			await _context.SaveChangesAsync();
			return result;
		}
	}
}