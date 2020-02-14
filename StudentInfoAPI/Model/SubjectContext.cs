using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.Model;
using System;

namespace StudentInfoAPI.Models
{
    public class SubjectContext : DbContext
    {
        public SubjectContext(DbContextOptions<SubjectContext> options)
            : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
    }
}