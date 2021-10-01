using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Entities
{
    public class genre : IEntity
    {
        public int id { get; set; }
        public string genreName { get; set; }
    }
}
