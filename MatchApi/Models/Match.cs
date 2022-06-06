using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchApi.Models
{
    public class Match
    {
        public string matchId { get; set; }

        //Needs to have a no-argument constructor for serialization/deserialization
        public Match()
        {
        }

        //A constructor taking all the properties as parameters
        public Match(string matchid)
        {
            matchId = matchid;
        }

        //Overrides the default ToString method
        public override string ToString()
        {
            //Simple string containing the property names and thier respective values
            return $"Id: {matchId}";
        }
    }
}
