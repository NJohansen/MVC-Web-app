using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Models
{
    public class AssignmentCourseContext : DbContext
    {
        public AssignmentCourseContext(DbContextOptions<AssignmentCourseContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment.Models.Course> Course { get; set; }

        public DbSet<Assignment.Models.Profile> Profile { get; set; }

        public DbSet<Assignment.Models.ProgrammingLanguage> ProgrammingLanguages{ get; set; }
    }
}
