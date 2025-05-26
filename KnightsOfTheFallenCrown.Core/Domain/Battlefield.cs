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
		[BattlefieldImage("Image/OpenPlains.jpg")]
		OpenPlains,
        [BattlefieldImage("Image/CastleSiege.jpg")]
        CastleSiege,
        [BattlefieldImage("Image/VillageSkirmish.jpg")]
        VillageSkirmish,
        [BattlefieldImage("Image/BridgeBattle.jpg")]
        BridgeBattle,
		CursedGraveyard,
		HauntedRuins,
		EnchantedForest,
		ShadowRealm,
		FrozenTundra,
		StormyCliffs,
		WreckedBattlefield,
		NomadCampRaid,
		UndergroundCatacombs,
		SkyCitadel

	}
	public enum Difficulty
	{
		Easy, Medium, Hard
	}
	public class Battlefield
	{
		public Guid ID { get; set; }
		public string BattlefieldName { get; set; }
		public BattlefieldType BattlefieldType { get; set; }
		public KnightTYPE? EnvironmentBoost {  get; set; }
		public string? BattlefieldDescription {  get; set; }
		public int Settlements { get; set; }
		public Difficulty DifficultyLevel { get; set; }
	//	public Lord? LordWhoDominatesThisBattlefield { get; set; }
		public Guid? ContinentID { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}

    [AttributeUsage(AttributeTargets.Field)]
    public class BattlefieldImageAttribute : Attribute
    {
        public string ImagePath { get; }
        public BattlefieldImageAttribute(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
