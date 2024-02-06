using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementDb.Models;

namespace SchoolManagementDb.Data
{
    public class ClassesDbContext : DbContext
    {
        public ClassesDbContext (DbContextOptions<ClassesDbContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolManagementDb.Models.Classes> Classes { get; set; } = default!;
    }
}
