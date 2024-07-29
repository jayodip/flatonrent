using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Application.Dtos
{
    public class FlatDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public int Price { get; set; } = default!;
        public int? FlatArea { get; set; }
        public string City { get; set; } = default!;
        public string? Street { get; set; }
        public string? FlatNumber { get; set; }
        public string? PostalCode { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string? Email { get; set; }
        public bool IsEditable { get; set; }
    }
}
