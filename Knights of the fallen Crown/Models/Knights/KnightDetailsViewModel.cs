using KnightsOfTheFallenCrown.Core.Domain;

namespace KnightsOfTheFallenCrown.Models.Knights
{
    public class KnightDetailsViewModel
    {
        public Guid ID { get; set; }
        public string KnightName { get; set; }
        public string KnightDescription { get; set; }
        public int KnightHealth { get; set; }
        public int KnightLevel { get; set; }
        public int KnightXP { get; set; }
        public int KnightXPNextLevel { get; set; }
        public KnightStatus KnightStatus { get; set; }

        public KnightTYPE KnightType { get; set; }
        public KnightPERK KnightPerk { get; set; }



        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabase> Image { get; set; } = new List<FileToDatabase>();



        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
