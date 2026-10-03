using DormAPI.Database.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Database.EF.Contexts
{
    public partial  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<ViewEmployee> ViewEmployees { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity => { 
                entity.HasKey(e => e.EmployeeId);


            });
        }
    }
}
