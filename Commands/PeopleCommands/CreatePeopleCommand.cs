using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApiCQRS.Data;
using PeopleApiCQRS.Models;

namespace PeopleApiCQRS.Commands.PeopleCommands
{
    public class CreatePeopleCommand
    {
        private readonly AppDbContext _context;
     
        public CreatePeopleCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<People> ExecuteAsync(People people)
        {
            _context.Peoples.Add(people);
            await _context.SaveChangesAsync();
            return people;
        }
    }
}