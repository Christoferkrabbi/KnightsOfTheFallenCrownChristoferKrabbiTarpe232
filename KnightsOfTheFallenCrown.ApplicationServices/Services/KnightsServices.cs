﻿

using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.ApplicationServices.Services
{
	public class KnightsServices : IKnightsServices
	{
		private readonly KnightsOfTheFallenCrownContext _context;
		private readonly IFileServices _fileServices;

		public KnightsServices(KnightsOfTheFallenCrownContext context, IFileServices fileServices)
		{
			_context = context;
			_fileServices = fileServices;
		}

		public async Task<Knight> DetailsAsync(Guid id)
		{
			var result = await _context.Knights
				.FirstOrDefaultAsync(x => x.ID == id);
			return result;
		}

		public async Task<Knight> Create(KnightDto dto)
		{
			Knight knight = new Knight();

			//set by service
			knight.ID = Guid.NewGuid();
			knight.KnightHealth = 100;
			knight.KnightXP = 0;
			knight.KnightXPNextLevel = 100;
			knight.KnightLevel = 0;
			knight.KnightStatus = Core.Domain.KnightStatus.Alive;
			knight.KnightWasBorn = DateTime.Now;
			knight.KnightHasDied = DateTime.Parse("01/01/9999 00:00:00");

			//set by user
			knight.KnightName = dto.KnightName;
			knight.KnightType = (Core.Domain.KnightTYPE)dto.KnightType;
			knight.PrimaryAttackName = dto.PrimaryAttackName;
			knight.PrimaryAttackPower = dto.PrimaryAttackPower;
			knight.SecondaryAttackName = dto.SecondaryAttackName;
			knight.SecondaryAttackPower = dto.SecondaryAttackPower;


			//set for db
			knight.CreatedAt = DateTime.Now;
			knight.UpdatedAt = DateTime.Now;





			if (dto.Files != null)
			{
				_fileServices.UploadFilesToDatabase(dto, knight);

			}
			await _context.Knights.AddAsync(knight);
			await _context.SaveChangesAsync();

			return knight;

		}
		public async Task<Knight> Update(KnightDto dto)
		{
			Knight knight = new Knight();

			// set by service
			knight.ID = dto.ID;
			knight.KnightHealth = dto.KnightHealth;
			knight.KnightXP = dto.KnightXP;
			knight.KnightXPNextLevel = dto.KnightXPNextLevel;
			knight.KnightLevel = dto.KnightLevel;
			knight.KnightStatus = (Core.Domain.KnightStatus)dto.KnightStatus;


			//set by user
			knight.KnightName = dto.KnightName;
			knight.KnightType = (Core.Domain.KnightTYPE)dto.KnightType;
			knight.PrimaryAttackName = dto.PrimaryAttackName;
			knight.PrimaryAttackPower = dto.PrimaryAttackPower;
			knight.SecondaryAttackName = dto.SecondaryAttackName;
			knight.SecondaryAttackPower = dto.SecondaryAttackPower;


			//set for db
			knight.CreatedAt = dto.CreatedAt;
			knight.UpdatedAt = DateTime.Now;

			//files
			if (dto.Files != null)
			{
				_fileServices.UploadFilesToDatabase(dto, knight);
			}
			_context.Knights.Update(knight);
			await _context.SaveChangesAsync();

			return knight;
		}
		public async Task<Knight> Delete(Guid id)
		{
			var result = await _context.Knights
				.FirstOrDefaultAsync(x => x.ID == id);
			_context.Knights.Remove(result);
			await _context.SaveChangesAsync();

			return result;
		}
	}
}