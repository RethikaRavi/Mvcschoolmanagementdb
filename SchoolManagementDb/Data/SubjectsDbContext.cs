using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementDb.Models;

namespace SchoolManagementDb.Data
{
    public class SubjectsDbContext : DbContext
    {
        public SubjectsDbContext (DbContextOptions<SubjectsDbContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolManagementDb.Models.Student> Student { get; set; } = default!;
    }
}
