using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Entities
{
    public class maincast:IEntity
    {
        public int id { get; set; }
        public string cast_name { get; set; }
        public int mov_id { get; set; }
    }
}
