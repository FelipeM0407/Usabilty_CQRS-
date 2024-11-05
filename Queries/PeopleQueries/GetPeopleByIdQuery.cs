using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApiCQRS.Data;
using PeopleApiCQRS.Models;

namespace PeopleApiCQRS.Queries.PeopleQueries
{
    public class GetPeopleByIdQuery
    {
        private readonly AppDbContext _context;

        public GetPeopleByIdQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<People?> ExecuteAsync(int id)
        {
            return await _context.Peoples.FindAsync(id);
        }
    }
}