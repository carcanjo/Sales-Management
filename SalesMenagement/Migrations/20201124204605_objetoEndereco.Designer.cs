﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesMenagement.Models.Context;

namespace SalesMenagement.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201124204605_objetoEndereco")]
    partial class objetoEndereco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesMenagement.Models.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameDepartaments");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SalesMenagement.Models.SalesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("SellerId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("SalesRecord");
                });

            modelBuilder.Entity("SalesMenagement.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<double>("BaseSalary");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("Cidade");

                    b.Property<int>("DepartmentsId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Endereco");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("NumeroCasa");

                    b.Property<string>("Uf");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentsId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("SalesMenagement.Models.SalesRecord", b =>
                {
                    b.HasOne("SalesMenagement.Models.Seller", "Seller")
                        .WithMany("SalesRecords")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("SalesMenagement.Models.Seller", b =>
                {
                    b.HasOne("SalesMenagement.Models.Departments", "Departments")
                        .WithMany("Sellers")
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
