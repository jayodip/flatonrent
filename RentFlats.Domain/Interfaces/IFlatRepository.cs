using RentFlats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Domain.Interfaces
{
    public interface IFlatRepository
    {
        Task Create(Flat flat);
        Task<IEnumerable<Flat>> GetAll();
        Task<Flat> GetById(int id);
        Task Save();
    }
}
