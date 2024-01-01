using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.BlogInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly RentACarContext _context;

        public BlogRepository(RentACarContext context)
        {
            _context = context;
        }

        public List<Blog> GetLastThreeBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
