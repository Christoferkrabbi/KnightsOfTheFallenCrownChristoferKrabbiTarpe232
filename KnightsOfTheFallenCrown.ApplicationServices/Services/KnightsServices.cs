
using KnightsOfTheFallenCrown.Core.Dto;
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

        public async Task<Knight>DetailsAsync(Guid id)
        {
            var result =await _context.Knights
                .FirstOrDefaultAsync(x=> x.ID == id);   
            return result;
        }

        public async Task<Knight> Create(KnightDto dto)
        {
            Knight knight = new Knight();

            //set by service
            knight.ID = Guid.NewGuid();
            knight.KnightHealth = 100;
            knight.KnightLevel = 0;

            //set by user
            knight.KnightType = (Core.Domain.KnightType)dto.KnightType;

            if(dto.Files != null)
            {
                
            }


        }
    }
}
