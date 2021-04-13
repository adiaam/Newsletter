using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newsletter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsletter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<NewsletterModel> Newsletters { get; set; }

    }
}

