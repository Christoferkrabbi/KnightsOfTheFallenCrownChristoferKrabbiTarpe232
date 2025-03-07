//Core.Dto.KnightDto

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.Dto
{
	public enum KnightTYPE
	{
		Vanguard, Heavy, Hybrid, Assassin,
	}
	public enum KnightPERK
	{
		AttackBoost, DefenceBoost,
	}
	public enum KnightStatus
	{
		Dead, Alive, OnGuard
	}

	public class KnightDto
	{



		public Guid ID { get; set; }
		public string KnightName { get; set; }
		public string? KnightDescription { get; set; }
		public int KnightHealth { get; set; }
		public int KnightLevel { get; set; }
		public int KnightXP { get; set; }
		public int KnightXPNextLevel { get; set; }
		public KnightStatus KnightStatus { get; set; }

		public KnightTYPE KnightType { get; set; }
		public KnightPERK KnightPerk { get; set; }


		public string PrimaryAttackName { get; set; }
		public int PrimaryAttackPower { get; set; }
		public string SecondaryAttackName { get; set; }
		public int SecondaryAttackPower { get; set; }
		public DateTime KnightWasBorn { get; set; }
		public DateTime KnightHasDied { get; set; }




		public List<IFormFile>? Files { get; set; }
		public IEnumerable<FileToDatabaseDto>? Image { get; set; } = new List<FileToDatabaseDto>();


		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}

}
