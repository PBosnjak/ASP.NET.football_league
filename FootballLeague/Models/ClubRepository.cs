using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class ClubRepository : GenericRepository<ClubModel>, IClubRepository
    {
        public ClubRepository(DataContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<bool> InsertClub(ClubModel model)
        {
            return await Create(model) > 0;
        }
    }
}
