

using KnightsOfTheFallenCrown.Core.Domain;
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
        private readonly IFileServices _fileServices;

        public KnightsServices(KnightsOfTheFallenCrownContext context, IFileServices fileServices)
        {
            _context=context;
            _fileServices = fileServices;
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
            knight.KnightName = dto.KnightName;
            


            
            if(dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, knight);

            }
            await _context.Knights.AddAsync(knight);
            await _context.SaveChangesAsync();

            return knight;

        }
    }
}
