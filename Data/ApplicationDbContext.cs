using dizajni_i_sistemit_softuerik.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Order>(o => o.PaymentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", CreatedAt = DateTime.UtcNow },
                new Role { Id = 2, Name = "Delivery", CreatedAt = DateTime.UtcNow },
                new Role { Id = 3, Name = "Guest", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, PermissionName = "READ_USERS", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 2, PermissionName = "EDIT_USERS", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 3, PermissionName = "DELETE_USERS", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 4, PermissionName = "CREATE_USERS", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 5, PermissionName = "READ_ORDERS", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 6, PermissionName = "EDIT_ORDERS", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 7, PermissionName = "DELETE_ORDERS", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 8, PermissionName = "CREATE_ORDERS", CreatedAt = DateTime.UtcNow }
            );


            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { RoleId = 1, PermissionId = 1 }, // Admin: READ_USERS
                new RolePermission { RoleId = 1, PermissionId = 2 }, // Admin: EDIT_USERS
                new RolePermission { RoleId = 1, PermissionId = 3 }, // Admin: DELETE_USERS
                new RolePermission { RoleId = 1, PermissionId = 4 }, // Admin: CREATE_USERS
                new RolePermission { RoleId = 2, PermissionId = 5 }, // Delivery: READ_ORDERS
                new RolePermission { RoleId = 2, PermissionId = 6 }, // Delivery: EDIT_ORDERS
                new RolePermission { RoleId = 3, PermissionId = 1 }  // Guest: READ_USERS
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
