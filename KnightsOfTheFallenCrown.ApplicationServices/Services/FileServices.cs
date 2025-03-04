using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using KnightsOfTheFallenCrown.Core.ServicesInterface;
using KnightsOfTheFallenCrown.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace KnightsOfTheFallenCrown.ApplicationServices.Services
{
    public class FileServices : IFileServices
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
                            KnightID = domain.ID
                        };

                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);

                    }
                }
            }
        }
		public void UploadFilesToDatabase(BattlefieldDto dto, Battlefield domain)
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
							BattlefieldID = domain.ID
						};

						image.CopyTo(target);
						files.ImageData = target.ToArray();
						_context.FilesToDatabase.Add(files);

					}
				}
			}
		}
		public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imageID = await _context.FilesToDatabase
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FilesToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;

        }

    }


}
