using KnightsOfTheFallenCrown.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.ServicesInterface
{
    public interface IKnightsServices
    {
        Task<Knights>DetailsAsync (Guid id);
    }
}
