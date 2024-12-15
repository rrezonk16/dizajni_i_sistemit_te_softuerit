﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dizajni_i_sistemit_softuerik.Data;

#nullable disable

namespace dizajni_i_sistemit_softuerik.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("ExpiryDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountApplied")
                        .HasColumnType("float");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TaxAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2344),
                            PermissionName = "READ_USERS"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2347),
                            PermissionName = "EDIT_USERS"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2348),
                            PermissionName = "DELETE_USERS"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2350),
                            PermissionName = "CREATE_USERS"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2351),
                            PermissionName = "READ_PRODUCTS"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2353),
                            PermissionName = "EDIT_PRODUCTS"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2354),
                            PermissionName = "DELETE_PRODUCTS"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2356),
                            PermissionName = "CREATE_PRODUCTS"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2357),
                            PermissionName = "READ_ORDERS"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2359),
                            PermissionName = "EDIT_ORDERS"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2360),
                            PermissionName = "DELETE_ORDERS"
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2361),
                            PermissionName = "CREATE_ORDERS"
                        });
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCarbonated")
                        .HasColumnType("bit");

                    b.Property<string>("MealType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2213),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2262),
                            Name = "Delivery"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2264),
                            Name = "Guest"
                        });
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            PermissionId = 1
                        },
                        new
                        {
                            RoleId = 1,
                            PermissionId = 2
                        },
                        new
                        {
                            RoleId = 1,
                            PermissionId = 3
                        },
                        new
                        {
                            RoleId = 1,
                            PermissionId = 4
                        },
                        new
                        {
                            RoleId = 2,
                            PermissionId = 5
                        },
                        new
                        {
                            RoleId = 2,
                            PermissionId = 6
                        },
                        new
                        {
                            RoleId = 3,
                            PermissionId = 9
                        },
                        new
                        {
                            RoleId = 1,
                            PermissionId = 12
                        });
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.OrderItem", b =>
                {
                    b.HasOne("dizajni_i_sistemit_softuerik.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dizajni_i_sistemit_softuerik.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.RolePermission", b =>
                {
                    b.HasOne("dizajni_i_sistemit_softuerik.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dizajni_i_sistemit_softuerik.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.User", b =>
                {
                    b.HasOne("dizajni_i_sistemit_softuerik.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("dizajni_i_sistemit_softuerik.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
