﻿// <auto-generated />
using GPAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GPAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("GPAPI.Models.Authtoken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("Expires")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedewerkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Token");

                    b.HasIndex("MedewerkerId");

                    b.ToTable("Authtokens");
                });

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

            modelBuilder.Entity("GPAPI.Models.Verlof", b =>
                {
                    b.Property<int>("VerlofID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedewerkerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reden")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Tot")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Van")
                        .HasColumnType("INTEGER");

                    b.HasKey("VerlofID");

                    b.HasIndex("MedewerkerId");

                    b.ToTable("Verlof");
                });

            modelBuilder.Entity("GPAPI.Models.Authtoken", b =>
                {
                    b.HasOne("GPAPI.Models.Medewerker", "Medewerker")
                        .WithMany()
                        .HasForeignKey("MedewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medewerker");
                });

            modelBuilder.Entity("GPAPI.Models.Verlof", b =>
                {
                    b.HasOne("GPAPI.Models.Medewerker", "Medewerker")
                        .WithMany("Verlofs")
                        .HasForeignKey("MedewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medewerker");
                });

            modelBuilder.Entity("GPAPI.Models.Medewerker", b =>
                {
                    b.Navigation("Verlofs");
                });
#pragma warning restore 612, 618
        }
    }
}
