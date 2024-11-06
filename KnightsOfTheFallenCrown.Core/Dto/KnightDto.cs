using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.Dto
{
    internal class KnightDto
    {
        public enum KnightTYPE
        {
            Vanguard, Heavy, Hybrid, Assassin,
        }
        public enum KnightPERK
        {
            AttackBoost, DefenceBoost,
        }



        public class Knight
        {
            public Guid ID { get; set; }
            public string KnightName { get; set; }
            public string KnightDescription { get; set; }
            public int KnightHealth { get; set; }
            public int KnightLevel { get; set; }
            public KnightTYPE KnightType { get; set; }
            public KnightPERK KnightPerk { get; set; }

            //public List <IFormFile>Files { get; set; }
            //public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        }
    }
}
