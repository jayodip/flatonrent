using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Domain.Entities
{
    public class Flat
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public int Price { get; set; } = default!;
        public int? FlatArea { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; } 
        public FlatAddress Address { get; set; } = default!;
        public int? AddressId { get; set; }
        public FlatContactDetails ContactDetails { get; set; } = default!;
        public int? ContactDetailsId { get; set; }
    }
}
