using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.ServicesInterface
{
    public interface IKnightsServices
    {
        Task<Knight>DetailsAsync (Guid id);
        Task<Knight> Create(KnightDto dto);
        Task<Knight> Update (KnightDto dto);
    }
}
