using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {}
        public DbSet<Lop>Lop{get;set;}

        public DbSet<Sinhvien>Sinhvien{get;set;}
        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<Employee>Employee{get;set;}
        
    }
}