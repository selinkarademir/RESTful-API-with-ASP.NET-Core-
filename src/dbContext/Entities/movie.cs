using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Entities
{
   public class movie:IEntity                                          //class Ientityden besleniyor
    {
        public int id { get; set; }
        public string movieName { get; set; }
        public int year { get; set; }
        public string plot { get; set; }
        public string duration { get; set; }
        public string avrRating { get; set; }
    }
}
