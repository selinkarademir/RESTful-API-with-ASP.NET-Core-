using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Entities
{
   public class director:IEntity
    {
        public int id { get; set; }
        public string directorName { get; set; }
    }
}
