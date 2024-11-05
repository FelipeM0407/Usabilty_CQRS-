using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleApiCQRS.Data;
using PeopleApiCQRS.Models;

namespace PeopleApiCQRS.Queries.PeopleQueries
{
    public class GetAllPeoplesQuery
    {
        private readonly AppDbContext _context;

        public GetAllPeoplesQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<People>> ExecuteAsync()
        {
            return await _context.Peoples.ToListAsync();
        }
    }
}