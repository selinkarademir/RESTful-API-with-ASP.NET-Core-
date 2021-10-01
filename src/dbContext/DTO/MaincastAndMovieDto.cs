using dbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.DTO
{
    public class MaincastAndMovieDto
    {
        public maincast maincast { get; set; }
        public movie movie { get; set; }
    }
}
