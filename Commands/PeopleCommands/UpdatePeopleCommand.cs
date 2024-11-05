using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleApiCQRS.Data;
using PeopleApiCQRS.Models;

namespace PeopleApiCQRS.Commands.PeopleCommands
{
    public class UpdatePeopleCommand
    {
        private readonly AppDbContext _context;

        public UpdatePeopleCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExecuteAsync(int id, People updatedPeople)
        {
            var people = await _context.Peoples.FindAsync(id);
            if (people == null) return false;

            people.FirstName = updatedPeople.FirstName;
            people.LastName = updatedPeople.LastName;
            people.Age = updatedPeople.Age;

            _context.Entry(people).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}