using KnightsOfTheFallenCrown.Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.Dto
{
	public class BattlefieldDto
	{
		public Guid ID { get; set; }
		public string BattlefieldName { get; set; }
		public BattlefieldType BattlefieldType { get; set; }
		public KnightTYPE EnvironmentBoost { get; set; }
		public string BattlefieldDescription { get; set; }
		public int Settlements { get; set; }
		public KardashevScale TechnicalLevel { get; set; }
	//	public Lord? LordWhoDominatesThisBattlefield { get; set; }
		public Guid? ContinentID { get; set; }

		public List<IFormFile> Files { get; set; }
		public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
