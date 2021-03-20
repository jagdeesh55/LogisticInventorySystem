using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogisticInventorySystem.Models;

namespace LogisticInventorySystem.Data
{
    public class LogisticInventorySystemItemContext : DbContext
    {
        public LogisticInventorySystemItemContext (DbContextOptions<LogisticInventorySystemItemContext> options)
            : base(options)
        {
        }

        public DbSet<LogisticInventorySystem.Models.Item> Item { get; set; }
    }
}
