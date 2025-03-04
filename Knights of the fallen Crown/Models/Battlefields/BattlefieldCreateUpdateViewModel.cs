using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using KnightTYPE = KnightsOfTheFallenCrown.Models.Knights.KnightTYPE;

namespace KnightsOfTheFallenCrown.Models.Battlefields
{
	public class BattlefieldCreateUpdateViewModel
	{
		public Guid? ID { get; set; }
		public string BattlefieldName { get; set; }
		public BattlefieldType BattlefieldType { get; set; }
		public KnightTYPE EnvironmentBoost { get; set; }
		public string BattlefieldDescription { get; set; }
		public int Settlements { get; set; }
		public KardashevScale TechnicalLevel { get; set; }
		public Lord? LordWhoDominatesThisBattlefield { get; set; }
		public Guid? ContinentID { get; set; }

		public List<IFormFile> Files { get; set; }
		public List<BattlefieldImageViewModel> Image { get; set; } = new List<BattlefieldImageViewModel>();

		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }

	}
}
