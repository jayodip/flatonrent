using RentFlats.Domain.Entities;
using RentFlats.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Infrastructure.Seeders
{
    public class FlatSeeder
    {
        private readonly RentFlatsDbContext _dbContext;

        public FlatSeeder(RentFlatsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Flats.Any())
                {
                    var flat = new Flat()
                    {
                        Title = "Kawalerka",
                        Price = 1650,
                        FlatArea = 28,
                        Address = new FlatAddress()
                        {
                            City = "Września",
                            Street = "Wielkopolska",
                            FlatNumber = "2a",
                            PostalCode = "62-300"
                        },
                        ContactDetails = new FlatContactDetails()
                        {
                            PhoneNumber = "123456789",
                            Email = "Mieszkanie@mieszkanie.com"
                        }
                        
                    };
                    _dbContext.Add(flat);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
