using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfTheFallenCrown.Core.Domain
{
    public class FileToDatabase
    {
        public Guid ID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
		public string ContentType { get; set; }
		public Guid? KnightID { get; set; }
        public Guid? BattlefieldID { get; set; }
        public BattlefieldType? BattlefieldType { get; set; }
		public string ImageSource { get; set; }
	}
}
