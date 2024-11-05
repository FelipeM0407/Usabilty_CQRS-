using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApiCQRS.Commands.PeopleCommands;
using PeopleApiCQRS.Data;
using PeopleApiCQRS.Models;
using PeopleApiCQRS.Queries.PeopleQueries;

namespace PeopleApiCQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetPeoples()
        {
            var query = new GetAllPeoplesQuery(_context);
            var peoples = await query.ExecuteAsync();
            return Ok(peoples);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeople(int id)
        {
            var query = new GetPeopleByIdQuery(_context);
            var people = await query.ExecuteAsync(id);
            if (people == null) return NotFound();
            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult<People>> CreatePeople(People people)
        {
            var command = new CreatePeopleCommand(_context);
            var createdPeople = await command.ExecuteAsync(people);
            return CreatedAtAction(nameof(GetPeople), new { id = createdPeople.Id }, createdPeople);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeople(int id, People people)
        {
            var command = new UpdatePeopleCommand(_context);
            var result = await command.ExecuteAsync(id, people);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            var command = new DeletePeopleCommand(_context);
            var result = await command.ExecuteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}