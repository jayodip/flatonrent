using Microsoft.EntityFrameworkCore;
using RentFlats.Domain.Entities;
using RentFlats.Domain.Interfaces;
using RentFlats.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Infrastructure.Repositories
{
    public class FlatRepository : IFlatRepository
    {
        private readonly RentFlatsDbContext _dbContext;

        public FlatRepository(RentFlatsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Flat flat)
        {
            _dbContext.Flats.Add(flat);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Flat>> GetAll()
            => await _dbContext.Flats.Include(e => e.ContactDetails)
            .Include(e => e.Address).ToListAsync();

        public async Task<Flat> GetById(int id)
            => await _dbContext.Flats.Include(e => e.ContactDetails)
            .Include(e => e.Address).FirstAsync(e => e.Id == id);

    }
}
