using KnightsOfTheFallenCrown.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.ServicesInterface
{
	public interface IEmailsServices
	{
		void SendEmail(EmailDto dto);
		void SendEmailToken(EmailTokenDto dto, string token);
	}
}
