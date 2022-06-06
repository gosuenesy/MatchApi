using MatchApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchApi.Managers
{
    public class MatchesManagerDB : IMatchesManager
    {
        //Remeber the Context from the constructor as it is used in all/most methods
        private MatchContext _context;

        //The constructor takes a Context from whoever initialized it
        public MatchesManagerDB(MatchContext context)
        {
            _context = context;
        }

        public Match Add(Match newMatch)
        {
            //Setting the Id to 0, so the database doesn't try to insert the ID from the caller
            //it should be the database that assigns the Id's
            //newMatch.Id = 0;
            _context.Matches.Add(newMatch);
            //Remember to call the savechanges everytime you make changes
            _context.SaveChanges();
            return newMatch;
        }

        public Match Delete(string id)
        {
            //Finds the Match that should be deleted using the Id
            //Uses the GetByID method because if we optimize this method, or change how to find a specific Match, we only need to implement this once
            Match MatchToBeDeleted = GetById(id);
            _context.Matches.Remove(MatchToBeDeleted);
            //Remember to call the savechanges everytime you make changes
            _context.SaveChanges();
            return MatchToBeDeleted;
        }

        public IEnumerable<Match> GetAll(string substring)
        {
            //Here we check if the different parameter values is set and if so filter the list
            //It is always recommended to make the database do as much of the work as possible
            IEnumerable<Match> Matches = from Match in _context.Matches
                                         where (substring == null || Match.matchId.Contains(substring))
                                         select Match;

            //Simply converts the DbSet to a List
            return Matches;
        }

        /*public IEnumerable<Match> GetAllBetweenQuality(int minQuality, int maxQuality)
        {
            //Here it asks for all Matches that have a quality between and including the parameters
            //It is always recommended to make the database do as much of the work as possible
            IEnumerable<Match> Matches = from Match in _context.Matches
                                      where Match.MatchQuality >= minQuality && Match.MatchQuality <= maxQuality
                                      select Match;

            //Simply converts the DbSet to a List
            return Matches;
        }*/

        public Match GetById(string id)
        {
            //The find method looks for the primary key (id)
            return _context.Matches.Find(id);
        }

        /*public Match Update(int id, Match updates)
        {
            //Finds the Match that should be updated using the Id
            //Uses the GetByID method because if we optimize this method, or change how to find a specific Match, we only need to implement this once
            Match MatchToBeUpdated = GetById(id);

            //update the values
            //Notice we don't update the Id, as it comes from the first parameter, and if the id is different in the updates, it gets ignored
            //We want the database to handle the Id's for us
            MatchToBeUpdated.Name = updates.Name;
            MatchToBeUpdated.MatchQuality = updates.MatchQuality;
            MatchToBeUpdated.Quantity = updates.Quantity;

            //Remember to call the savechanges everytime you make changes
            //In this case it can see that the MatchToBeUpdated has been updated
            _context.SaveChanges();

            return MatchToBeUpdated;
        }*/
    }
}
