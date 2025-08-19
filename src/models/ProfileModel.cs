using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAppAsync.src.models
{
    public class ProfileModel
    {
        public Guid ProfileId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}