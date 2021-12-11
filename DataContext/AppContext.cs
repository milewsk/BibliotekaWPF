using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaWPF.Models;

namespace BibliotekaWPF.Context
{
    class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<User_Group> User_Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NowaKsiegarniaWPF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.isAdmin).HasDefaultValue(0);

            modelBuilder.Entity<Book>().Property(b => b.Available).HasDefaultValue(1);

            modelBuilder.Entity<Book>().HasOne<Author>(b => b.BookAuthor).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>().HasOne<Category>(b => b.Category).WithMany(c => c.Books).HasForeignKey(b => b.IdCategory);

            modelBuilder.Entity<Meeting>()
                        .HasOne<Group>(m => m.Group)
                        .WithMany(g => g.Meetings)
                        .HasForeignKey(m => m.IdGroup)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Loan>()
                        .HasOne<User>(l => l.User)
                        .WithMany(u => u.Loans)
                        .HasForeignKey(l => l.IdUser)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Purchase>()
                        .HasOne<User>(p => p.User)
                        .WithMany(u => u.Purchases)
                        .HasForeignKey(p => p.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            // User-Group relationship
            modelBuilder.Entity<User_Group>().HasKey(ug => new { ug.IdUser, ug.IdGroup });
            modelBuilder.Entity<User_Group>().HasOne<User>(ug => ug.User).WithMany(u => u.User_Groups).HasForeignKey(ug => ug.IdUser);
            modelBuilder.Entity<User_Group>().HasOne(ug => ug.Group).WithMany(g => g.User_Groups).HasForeignKey(ug => ug.IdGroup);

        }
    }
}
