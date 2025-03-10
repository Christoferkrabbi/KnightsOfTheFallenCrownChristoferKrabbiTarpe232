﻿using KnightsOfTheFallenCrown.Core.Domain;

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
    public enum KnightStatus
    {
        Dead, Alive, OnGuard
    }


    public class KnightsIndexViewModel
    {
        public Guid KnightID { get; set; }
        public string KnightName { get; set; }
        public string KnightDescription { get; set; }
        public int KnightHealth { get; set; }
        public int KnightLevel { get; set; }
        public int PrimaryAttack { get; set; }
        public KnightTYPE KnightType { get; set; }
        public KnightPERK KnightPerk { get; set; }
        public KnightStatus KnightStatus { get; set; }

        //ainult Db
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
