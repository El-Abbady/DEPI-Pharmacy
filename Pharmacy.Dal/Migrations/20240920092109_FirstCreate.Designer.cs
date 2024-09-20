﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Pharmacy.Dal.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    [Migration("20240920092109_FirstCreate")]
    partial class FirstCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Category_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Category_Name");

                    b.HasKey("CategoryId")
                        .HasName("PK__Category__6DB38D4E89B099FD");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Order_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Order_Date");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Order_Status");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Total_Amount");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__F1E4639B6F81FAC8");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Order_Detail_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_ID");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_ID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Unit_Price");

                    b.HasKey("OrderDetailId")
                        .HasName("PK__OrderDet__1581C703D8487056");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Payment_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Amount_Paid");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_ID");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Payment_Date");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Payment_Type");

                    b.HasKey("PaymentId")
                        .HasName("PK__Payment__DA6C7FE19F740D6B");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Product_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category_ID");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("ExpiryDate")
                        .HasColumnType("date")
                        .HasColumnName("Expiry_Date");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Image_URL");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Product_Name");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int")
                        .HasColumnName("Quantity_InStock");

                    b.HasKey("ProductId")
                        .HasName("PK__Product__9834FB9A00909A8A");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Models.ShoppingCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Cart_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_ID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("CartId")
                        .HasName("PK__Shopping__D6AB58B9F5D19FE6");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("First_Name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Last_Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Phone_Number");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("Role_ID");

                    b.HasKey("UserId")
                        .HasName("PK__Users__206D919097E0E139");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Role_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Role_Name");

                    b.HasKey("RoleId")
                        .HasName("PK__UserRole__D80AB49BCDA5EF84");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Orders__User_ID__412EB0B6");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.OrderDetail", b =>
                {
                    b.HasOne("Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__440B1D61");

                    b.HasOne("Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__OrderDeta__Produ__44FF419A");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Models.Payment", b =>
                {
                    b.HasOne("Models.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__Payment__Order_I__47DBAE45");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.HasOne("Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Product__Categor__398D8EEE");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Models.ShoppingCart", b =>
                {
                    b.HasOne("Models.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ShoppingC__Produ__4BAC3F29");

                    b.HasOne("Models.User", "User")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__ShoppingC__User___4AB81AF0");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ShoppingCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
