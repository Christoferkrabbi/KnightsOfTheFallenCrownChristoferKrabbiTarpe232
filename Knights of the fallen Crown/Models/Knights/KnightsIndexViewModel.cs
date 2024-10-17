namespace KnightsOfTheFallenCrown.Models.Knights
{

    public enum KnightTYPE
    {
        Vanguard, Heavy, Hybrid, Assassin,
    }
    public enum KnightPERK
    {
        AttackBoost, DefenceBoost,
    }


    public class KnightsIndexViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public KnightTYPE KnightType { get; set; }
        public KnightPERK KnightPerk { get; set; }

    }
}
