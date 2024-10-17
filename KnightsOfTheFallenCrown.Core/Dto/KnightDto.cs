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



        public class Knights
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Health { get; set; }
            public int Level { get; set; }
            public KnightTYPE KnightType { get; set; }
            public KnightPERK KnightPerk { get; set; }

            //public List <IFormFile>Files { get; set; }
            //public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        }
    }
}
