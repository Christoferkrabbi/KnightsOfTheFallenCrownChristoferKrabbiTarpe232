using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.Domain
{
	public class Continents
	{
		public enum Continent
		{
			Valdros,
			Eryndor,
			Caelvaran,
			Drelmor,
			Thalmyra,
			Nocthyr
		}
		public static class ContinentDescriptions
		{
			public static readonly Dictionary<Continent, string> Descriptions = new()
	{
		{ Continent.Valdros, "The Continent of Iron and Honor — knightly orders, warring kingdoms, and ancient relics." },
		{ Continent.Eryndor, "The Emerald Wilds — overgrown forests, druidic tribes, and fae beasts." },
		{ Continent.Caelvaran, "The Skybound Isles — floating landmasses, griffin riders, and skyships." },
		{ Continent.Drelmor, "The Ashen Wastes — cursed lands, dragonfire ruins, and undead remnants." },
		{ Continent.Thalmyra, "The Sunlit Realm — golden cities, holy wars, and desert mystics." },
		{ Continent.Nocthyr, "The Shadowlands — eternal twilight, vampire lords, and gothic horrors." }
	};
		}
	}
}
