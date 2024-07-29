using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Domain.Entities
{
    public class FlatAddress
    {
        public int Id { get; set; }
        public string City { get; set; } = default!;
        public string? Street { get; set; } 
        public string? FlatNumber { get; set; } 
        public string? PostalCode { get; set; } 
        public Flat Flat { get; set; } = default!;
        
    }
}
