﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Models;

#nullable disable

namespace GPAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("GPAPI.Models.Medewerker", b =>
                {
                    b.Property<int>("MedewerkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .HasColumnType("TEXT");

                    b.Property<string>("Wachtwoord")
                        .HasColumnType("TEXT");

                    b.HasKey("MedewerkerID");

                    b.ToTable("Medewerkers");
                });
#pragma warning restore 612, 618
        }
    }
}
