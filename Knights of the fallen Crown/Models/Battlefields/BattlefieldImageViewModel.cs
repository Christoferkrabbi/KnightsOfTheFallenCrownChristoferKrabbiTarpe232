using KnightsOfTheFallenCrown.Core.Domain;

namespace KnightsOfTheFallenCrown.Models.Battlefields
{
	public class BattlefieldImageViewModel
	{
		public Guid ImageID { get; set; }
		public string ImageTitle { get; set; }
		public byte[] ImageData { get; set; }
		public string Image { get; set; }
		public Guid? BattlefieldID { get; set; }
		public BattlefieldType? BattlefieldType { get; set; }
	}
}
