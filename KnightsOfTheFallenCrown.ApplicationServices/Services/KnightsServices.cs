using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.ApplicationServices.Services
{
    public class KnightsServices : IKnightsServices
    {
        private readonly KnightsOfTheFallenCrownContext _context;

        public KnightsServices(KnightsOfTheFallenCrownContext context)
        {
            _context=context;
        }

        public async Task<Knights>DetailsAsync(Guid id)
        {
            var result =await _context.Knight
                .FirstOrDefaultAsync(x=> x.ID == id);   
            return result;
        }
    }
}
