using FootballLeague.Models;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System;
using System.Linq;
using System.Threading.Tasks;

public interface IClubRepository : IGenericRepository<ClubModel>
{
    Task<bool> InsertClub(ClubModel model);
}