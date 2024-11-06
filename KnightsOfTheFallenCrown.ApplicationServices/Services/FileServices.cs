using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using Microsoft.Extensions.Hosting;

namespace KnightsOfTheFallenCrown.ApplicationServices.Services
{
    public class FileServices : IFileservices
    {
        private readonly IHostEnvironment _webHost;
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
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            TitanID = domain.ID
                        };

                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);

                    }
                }
            }


        }
    }
}
