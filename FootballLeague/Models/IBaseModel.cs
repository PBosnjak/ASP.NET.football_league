using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public interface IBaseModel
    {
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
