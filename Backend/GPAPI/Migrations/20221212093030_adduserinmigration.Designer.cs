﻿// <auto-generated />
using GPAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GPAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20221212093030_adduserinmigration")]
    partial class adduserinmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("GPAPI.Models.Authtoken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("Expires")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("MedewerkerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Token");

                    b.ToTable("Authtokens");
                });

            modelBuilder.Entity("GPAPI.Models.Medewerker", b =>
                {
                    b.Property<ulong>("MedewerkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedewerkerType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Wachtwoord")
                        .HasColumnType("TEXT");

                    b.HasKey("MedewerkerID");

                    b.ToTable("Medewerkers");
                });

            modelBuilder.Entity("GPAPI.Models.Team", b =>
                {
                    b.Property<ulong>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GPAPI.Models.Verlof", b =>
                {
                    b.Property<int>("VerlofID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("MedewerkerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reden")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Tot")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Van")
                        .HasColumnType("INTEGER");

                    b.HasKey("VerlofID");

                    b.HasIndex("MedewerkerID");

                    b.ToTable("Verlof");
                });

            modelBuilder.Entity("GPAPI.Models.Verlof", b =>
                {
                    b.HasOne("GPAPI.Models.Medewerker", null)
                        .WithMany("Verlofs")
                        .HasForeignKey("MedewerkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPAPI.Models.Medewerker", b =>
                {
                    b.Navigation("Verlofs");
                });
#pragma warning restore 612, 618
        }
    }
}
