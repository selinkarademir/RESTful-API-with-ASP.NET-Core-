using dbContext.Entities;
using dbContext.Repository.Context;
using dbContext.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Repository.Base
{
   public class MainCastRepository:BaseRepository<maincast, NPGContext >, IMainCastRepository
    {
    }
}
