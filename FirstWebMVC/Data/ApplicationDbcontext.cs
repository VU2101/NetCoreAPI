using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;
using firstWebMVC.model;

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {}
        public DbSet<Person>Person{get;set;}
        public DbSet<Lop>Lop{get;set;}

        public DbSet<Sinhvien>Sinhvien{get;set;}
        
         public DbSet<Customer>Customers{get;set;}
         public DbSet<Dangnhap>Dangnhap{get;set;}
         public DbSet<Nhapvao>Nhapvao{get;set;}
    }
}