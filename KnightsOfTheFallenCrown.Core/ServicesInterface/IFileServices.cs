using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.ServicesInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(KnightDto dto, Knight domain);

		Task UploadFilesToDatabase(BattlefieldDto dto, Battlefield domain, BattlefieldType battlefieldType);
		Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);

		Task GetImageSource(BattlefieldDto dto, Battlefield domain, BattlefieldType battlefieldType);
	}
}
