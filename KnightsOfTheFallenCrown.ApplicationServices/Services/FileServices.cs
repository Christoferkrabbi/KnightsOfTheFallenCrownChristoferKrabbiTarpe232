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
		public async Task UploadFilesToDatabase(BattlefieldDto dto, Battlefield battlefield, BattlefieldType battlefieldType)
		{
			if (dto.Files != null && dto.Files.Count > 0)
			{
				foreach (var image in dto.Files)
				{
					using (var target = new MemoryStream())
					{
						await image.CopyToAsync(target);

						var file = new FileToDatabase()
						{
							ID = Guid.NewGuid(),
							ImageTitle = $"{battlefieldType}_{Guid.NewGuid()}_{Path.GetFileNameWithoutExtension(image.FileName)}",
							BattlefieldID = battlefield.ID,
							BattlefieldType = battlefieldType,
							ImageData = target.ToArray(),
							
							ImageSource = GetImageSource(battlefieldType)
						};

						await _context.FilesToDatabase.AddAsync(file);
					}
				}
				await _context.SaveChangesAsync();
			}
		}
		private string GetImageSource(BattlefieldType type)
		{
			return type switch
			{
				BattlefieldType.OpenPlains => "./lib/gameasset/Image/Battlefields/OpenPlains.jpg",
				BattlefieldType.CastleSiege => "/images/CastleSiege.jpg",
				BattlefieldType.CursedGraveyard => "/images/CursedGraveyard.jpg",
				//pooleli
				
				_ => "/images/battlefield-default.jpg"
			};
		}
		public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
		{
			var image = await _context.FilesToDatabase
				.FirstOrDefaultAsync(x => x.ID == dto.ID);

			if (image == null) return null;

			// Optional: Add type-specific deletion logic if needed
			if (image.BattlefieldType.HasValue)
			{
				// Example: Special handling for certain types
				if (image.BattlefieldType == BattlefieldType.CursedGraveyard)
				{
					// Additional cleanup for cursed graveyard images
				}
			}

			_context.FilesToDatabase.Remove(image);
			await _context.SaveChangesAsync();
			return image;
		}


	}


}
