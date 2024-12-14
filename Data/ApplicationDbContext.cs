﻿using dizajni_i_sistemit_softuerik.Entities;
using Microsoft.EntityFrameworkCore;

namespace dizajni_i_sistemit_softuerik.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)          
                .WithOne(p => p.Order)           
                .HasForeignKey<Order>(o => o.PaymentId) 
                .OnDelete(DeleteBehavior.NoAction); 
=======

            // modelBuilder.Entity<Order>()
            //     .HasOne(o => o.Payment)
            //     .WithOne(p => p.Order)
            //     .HasForeignKey<Order>(o => o.PaymentId)
            //     .OnDelete(DeleteBehavior.NoAction);
>>>>>>> 0818d28faaf7311aad42fe8ed77d9543e7fa5603

            base.OnModelCreating(modelBuilder);
        }


    }
}
