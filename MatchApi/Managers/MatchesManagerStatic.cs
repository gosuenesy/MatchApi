using MatchApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchApi.Managers
{
    public class MatchesManagerStatic : IMatchesManager
    {
        //Keeps track of ids, in order for all Matches to have a unique ID
        //private static int _nextId = 1;
        //Creates the list of Matches and fills it with 3 Matches to begin with
        //The 3 Matches is only for testing purposes
        private static readonly List<Match> Data = new List<Match>
        {
            //new Match {matchId = "fde18106-9a5e-4efb-b593-4085bea98442"},
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        //Returns all Matches in the List, in a new List, if the all the parameters is null (or 0 for int values, default value)
        //if the substring is not null, the it returns all Matches that has a name containing the substring
        //the filter is case-insensitive
        //Specified default values, so one using the method doesn't have to specify the values if they don't have them
        public IEnumerable<Match> GetAll(string substring)
        {
            List<Match> result = new List<Match>(Data);
            if (substring != null)
            {
                result = result.FindAll(Match => Match.matchId.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        //Filter function to return all Matches having a quality between minQuality and maxQuality
        /*public IEnumerable<Match> GetAllBetweenQuality(int minQuality, int maxQuality)
        {
            List<Match> result = new List<Match>(Data);
            result = result.FindAll(Match => Match.MatchQuality >= minQuality && Match.MatchQuality <= maxQuality);
            return result;
        }*/

        //Returns a specific Match from the list
        //return null if the id is not found
        public Match GetById(string id)
        {
            return Data.Find(Match => Match.matchId == id);
        }

        //Adds a new Match to the list, and assigns it the next id
        //returns the newly added Match
        public Match Add(Match newMatch)
        {
            Data.Add(newMatch);
            return newMatch;
        }

        //Deletes the Match from the list with the specific Id
        //Returns null of no Match has the Id
        public Match Delete(string id)
        {
            Match Match = Data.Find(Match1 => Match1.matchId == id);
            if (Match == null) return null;
            Data.Remove(Match);
            return Match;
        }

        //Updates the values of the Match with the specific Id
        //Returns null of no Match has the Id
        //Notice Id is not changed in the Match from the List
        /*public Match Update(int id, Match updates)
        {
            Match Match = Data.Find(Match1 => Match1.Id == id);
            if (Match == null) return null;
            Match.Name = updates.Name;
            Match.MatchQuality = updates.MatchQuality;
            Match.Quantity = updates.Quantity;
            return Match;
        }*/
    }
}
