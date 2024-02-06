using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementDb.Models;

namespace SchoolManagementDb.Data
{
    public class SubjectDbContext : DbContext
    {
        public SubjectDbContext (DbContextOptions<SubjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolManagementDb.Models.Subject> Subject { get; set; } = default!;
    }
}
