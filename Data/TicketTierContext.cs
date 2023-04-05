using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketTier.Models;

namespace TicketTier.Data
{
    public class TicketTierContext : DbContext
    {
        public TicketTierContext (DbContextOptions<TicketTierContext> options)
            : base(options)
        {
        }

        public DbSet<TicketTier.Models.Ticket> Ticket { get; set; } = default!;
    }
}
