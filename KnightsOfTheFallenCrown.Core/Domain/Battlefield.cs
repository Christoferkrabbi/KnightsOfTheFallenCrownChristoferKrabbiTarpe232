using KnightsOfTheFallenCrown.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.Domain
{
	public enum BattlefieldType
	{
		Open_Plains,
		Castle_Siege,
		Village_Skirmish,
		Bridge_Battle,
		Cursed_Graveyard,
		Haunted_Ruins,
		Enchanted_Forest,
		Shadow_Realm,
		Fiery_Wasteland,
		Frozen_Tundra,
		Stormy_Cliffs,
		Flooded_Marshlands,
		Wrecked_Battlefield,
		Nomad_Camp_Raid,
		Underground_Catacombs,
		Sky_Citadel

	}
	public enum KardashevScale
	{
		Type1, Type2, Type3
	}
	public class Battlefield
	{
		public Guid ID { get; set; }
		public string BattlefieldName { get; set; }
		public BattlefieldType BattlefieldType { get; set; }
		public KnightTYPE? EnvironmentBoost {  get; set; }
		public string BattlefieldDescription {  get; set; }
		public int Settlements { get; set; }
		public KardashevScale TechnicalLevel { get; set; }
		public Lord? LordWhoDominatesThisBattlefield { get; set; }
		public Guid? ContinentID { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }

	}
}
