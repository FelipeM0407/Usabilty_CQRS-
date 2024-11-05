using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApiCQRS.Data;

namespace PeopleApiCQRS.Commands.PeopleCommands
{
    public class DeletePeopleCommand
    {
        private readonly AppDbContext _context;

        public DeletePeopleCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            var people = await _context.Peoples.FindAsync(id);
            if (people == null) return false;

            _context.Peoples.Remove(people);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}