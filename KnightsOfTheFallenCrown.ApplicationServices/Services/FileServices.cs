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
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _ webHost;
        private readonly KnightsOfTheFallenCrownContext _context;

        public FileServices
       ( 
           IHostEnvironment webHost,
            KnightsOfTheFallenCrownContext context
        )
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(KnightDto dto, Knight domain)
        {
            if(dto.Files != null && dto.Files.Count > 0)
            { 
                foreach(var image in dto.Files) 
                {
                    using (var target = new MemoryStream()) 
                    { 
                        FileToDatabase files = null FileToDatabase()
                        {
                            ID = Guid.NewGuid();
                            ImageTitle = image.FileName;
                            


                        }
                    
                    }
                }
            }


        }

        public async Task<Knight> DetailsAsync(Guid id)
        {
            var result = await _context.Knights
                .FirstOrDefaultAsync(x=>x.ID==id);
            return result
        }
 
    }
}
