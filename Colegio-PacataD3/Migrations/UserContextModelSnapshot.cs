﻿// <auto-generated />
using Colegio_PacataD3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Colegio_PacataD3.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Colegio_PacataD3.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<int>("Decidir")
                        .HasColumnType("int");

                    b.Property<int>("DecidirE")
                        .HasColumnType("int");

                    b.Property<int>("Hacer1")
                        .HasColumnType("int");

                    b.Property<int>("Hacer2")
                        .HasColumnType("int");

                    b.Property<int>("Hacer3")
                        .HasColumnType("int");

                    b.Property<int>("Hacer4")
                        .HasColumnType("int");

                    b.Property<int>("IdEst")
                        .HasColumnType("int");

                    b.Property<int>("Saber1")
                        .HasColumnType("int");

                    b.Property<int>("Saber2")
                        .HasColumnType("int");

                    b.Property<int>("Saber3")
                        .HasColumnType("int");

                    b.Property<int>("Saber4")
                        .HasColumnType("int");

                    b.Property<int>("Ser")
                        .HasColumnType("int");

                    b.Property<int>("SerE")
                        .HasColumnType("int");

                    b.Property<int>("Trimester")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Colegio_PacataD3.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("IdTeacher")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Colegio_PacataD3.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Birth")
                        .HasColumnType("text");

                    b.Property<int>("Ci")
                        .HasColumnType("int");

                    b.Property<string>("Course")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumberReference")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Rol")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
