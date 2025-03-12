using System;
using System.Linq;
using BakeryProject.Domain.Entities;
using BakeryProject.Domain.Interfaces;
using BakeryProject.Infrastructure;

namespace BakeryProject.Application.Services
{
    public class BreadFactory : IBreadFactory
    {
        private readonly BakeryDbContext _context;

        public BreadFactory(BakeryDbContext context)
        {
            _context = context;
        }

        public Bread CreateBread(string breadName)
        {
            var trimmedName = breadName.Trim().ToLower();
            var bread = _context.Breads
                .FirstOrDefault(b => b.Name.Trim().ToLower() == trimmedName);
            if (bread == null)
                throw new ArgumentException("Invalid bread name: " + breadName);
            return bread;
        }
    }
}
