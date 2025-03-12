using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.ServicesInterface
{
	public interface IBattlefieldsServices
	{
		Task<Battlefield> DetailsAsync(Guid id);
		Task<Battlefield> Create(BattlefieldDto dto);
		Task<Battlefield> Delete(Guid id);
		Task<Battlefield> Update(BattlefieldDto dto);
	}
}