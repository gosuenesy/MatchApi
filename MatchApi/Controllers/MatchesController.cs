using MatchApi.Managers;
using MatchApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        //A object of the IMatchesManager interface
        //Removed the initialization here, as it needs the context from the Constructor
        private IMatchesManager _manager;

        //Added this constructor to be able to use the MatchContext in the Manager
        public MatchesController(MatchContext context)
        {
            //an if statement could be implemented here, telling the Service which Manager to use
            _manager = new MatchesManagerDB(context);
        }

        // GET: api/Matches
        // GET: api/Matches?substring=book&minimumQuality=1&minimumQuantity=1
        //Gets all the Matches in the managers list
        //Is able to filter the result by either:
        //Name containing the substring (case-insensitive)
        //Quality is more or equal to minimumQuality
        //Quantity is more or equal to minimumQuantity
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Match>> Get([FromQuery] string substring)
        {
            IEnumerable<Match> result = _manager.GetAll(substring);
            if (result.Count() == 0) return NoContent();
            return Ok(result);
        }

        // GET: api/Matches/quality?minQuality=1&maxQuality=10
        //Gets all the Matches in the managers list
        //Is able to filter the result by either:
        //Name containing the substring (case-insensitive)
        //Quality is more or equal to minimumQuality
        //Quantity is more or equal to minimumQuantity
        //Changed route so the webserver knows which funtion to execute
        /*[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("quality")]
        public ActionResult<IEnumerable<Match>> Get([FromQuery] int minQuality, [FromQuery] int maxQuality)
        {
            IEnumerable<Match> result = _manager.GetAllBetweenQuality(minQuality, maxQuality);
            if (result.Count() == 0) return NoContent();
            return Ok(result);
        }*/

        // GET api/Matches/5
        //Gets a specific Match in the managers list, return null if the object wasn't found
        //Notice the "{id}" part of the annotation, this makes the URI to the object expect a /int
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Match> GetId(string id)
        {
            Match result = _manager.GetById(id);
            if (result == null) return NotFound("No such Match, id: " + id);
            return Ok(result);
        }

        // POST api/Matches
        //Sends the new object to list, which gives it a new ID and return the newly created object
        //Notice the FromBody part of the parameter, this expects a Json body from the request
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Match> Post([FromBody] Match newMatch)
        {
            Match result = _manager.Add(newMatch);
            return Created($"/api/Matches/{result.matchId}", result);
        }

        // PUT api/Matches/5
        //Sends the id and the Match object to the manager to update the values
        //The id in the object is ignored
        //Returns null if no Matches has the id
        //As seen here, we can mix different ways of expected data from the client
        //Notice the "{id}" part of the annotation, this makes the URI to the object expect a /int
        //Notice the FromBody part of the parameter, this expects a Json body from the request
        /*[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Match> Put(int id, [FromBody] Match updatedMatch)
        {
            Match result = _manager.Update(id, updatedMatch);
            if (result == null) return NotFound("No such Match, id: " + id);
            return Ok(result);
        }*/

        // DELETE api/Matches/5
        //Asks the Manager to delete the Match with the specific id
        //Returns null if the Match was not found
        //Notice the "{id}" part of the annotation, this makes the URI to the object expect a /int
        //Here we specify that it is only requests coming from https://zealand.dk that is allowed
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Match> Delete(string id)
        {
            Match result = _manager.Delete(id);
            if (result == null) return NotFound("No such Match, id: " + id);
            return Ok(result);
        }
    }
}
