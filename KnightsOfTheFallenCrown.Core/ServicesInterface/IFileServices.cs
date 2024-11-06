using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.ServicesInterface
{
    public interface IFileservices
    {
        void UploadFilesToDatabase(
            KnightDto dto, Knight domain);
    }
}
