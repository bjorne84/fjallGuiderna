using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using fjallGuiderna.Models;

namespace fjallGuiderna.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<fjallGuiderna.Models.Category> Category { get; set; }
        public DbSet<fjallGuiderna.Models.Location> Location { get; set; }
        public DbSet<fjallGuiderna.Models.Guide> Guide { get; set; }
        public DbSet<fjallGuiderna.Models.NatureActivity> NatureActivity { get; set; }
        public DbSet<fjallGuiderna.Models.Contact> Contact { get; set; }
    }
}
