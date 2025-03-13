namespace KnightsOfTheFallenCrown.Models.Knights
{
    public class KnightDeleteViewModel
    {
        public Guid? ID { get; set; }
        public string KnightName { get; set; }
        public int KnightHealth { get; set; }
        public int KnightXP { get; set; }
        public int KnightXPNextLevel { get; set; }
        public int KnightLevel { get; set; }
        public KnightTYPE KnightType { get; set; }
        public KnightStatus KnightStatus { get; set; }
        public int PrimaryAttackPower { get; set; }
        public string PrimaryAttackName { get; set; }
        public int SecondaryAttackPower { get; set; }
        public string SecondaryAttackName { get; set; }

        public List<IFormFile> Files { get; set; }
        public List<KnightImageViewModel> Image { get; set; } = new List<KnightImageViewModel>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
