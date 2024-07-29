using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Domain.Entities
{
    public class FlatContactDetails
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string? Email { get; set; }
        public Flat Flat { get; set; } = default!;
        
    }
}
