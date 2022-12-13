﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _03___Infrastructure.DBContexts;

#nullable disable

namespace _03Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeDBContext))]
    [Migration("20221213194257_InitialMigration2")]
    partial class InitialMigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_01___Domain.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<float>("age")
                        .HasColumnType("real");

                    b.Property<float>("height")
                        .HasColumnType("real");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("weight")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
