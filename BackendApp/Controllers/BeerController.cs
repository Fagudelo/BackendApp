using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace BackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController(BackendBarContext context) : ControllerBase
    {
        private BackendBarContext _context = context;

        [HttpGet]
        public IEnumerable<Beer> Get() => [.. _context.Beers];

        [HttpPost]
        public IActionResult Add(Beer beer)
        {
            if (beer == null)
            {
                return BadRequest("No se envió la información");
            }

            _context.Beers.Add(beer);
            _context.SaveChangesAsync();

            return Ok(beer);
        }

    //    public void UpdateBeer(Beer beer)
    //    {
    //        var existingBeer = _context.Beers.Find(beer.BeerId);

    //        if (existingBeer != null)
    //        {
    //            // Update the properties of the existing entity
    //            existingBeer.BeerId = beer.BeerId;
    //            existingBeer.Name = beer.Name;
    //            // ... update other properties as needed

    //            _context.SaveChanges(); // Save changes to the database
    //        }
    //        else
    //        {
    //            // Handle the case where the entity to be updated is not found
    //            // This could be throwing an exception, logging, etc.
    //        }
    //    }
    //}

    //public void UpdateBeer(Beer beer)
    //{
    //    _repository.UpdateEntity(updatedEntity);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> ModifyBeer(int id, Beer beer)
    //{
    //    if (id != beer.BeerId)
    //    {
    //        return BadRequest();
    //    }
    //    _context.Entry(beer).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!BeerExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }
    //}


    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer != null)
            {
                _context.Beers.Remove(beer);
                await _context.SaveChangesAsync();
                return Ok("Se ha eliminado la cerveza " + beer.Name);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Beer beer)
        {
            var existingBeer = Beer.FirstOrDefault(b => b.Equals (id));

            if (existingBeer == null)
            {
                return NotFound(); // Return 404 if the resource with the specified id is not found
            }

            // Update the existing beer with the new data
            existingBeer.Equals  (beer.BeerId);
            existingBeer.Equals  (beer.Name);

            return Ok(existingBeer); // Return the updated beer
        }
    }

    //private bool BeerExists(int id)
    //{
    //    return _context.Beers.Any(e => e.BeerId == id);
    //}

    //public void DeleteEntity(int beerId)
    //{
    //    var beer = _context.Beers.Find(beerId);

    //    if (beer != null)
    //    {
    //        _context.Beers.Remove(beer);
    //        _context.SaveChanges();
    //    }
    //}

    //public IActionResult Add(Beer beer) 
    //{
    //    if (beer.Name.Equals(""))
    //    {
    //        return BadRequest("No se envió la información");
    //    }

    //    return Ok(beer);
    //}
}
