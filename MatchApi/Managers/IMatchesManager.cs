using MatchApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchApi.Managers
{
    //This interface was extracted from the MatchesManager class
    //Nothing has been added manually
    public interface IMatchesManager
    {
        Match Add(Match newMatch);
        Match Delete(string id);
        IEnumerable<Match> GetAll(string substring);
        //IEnumerable<Match> GetAllBetweenQuality(int minQuality, int maxQuality);
        Match GetById(string id);
        //Match Update(int id, Match updates);
    }
}
