﻿// <auto-generated />
using System;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCapital")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsVisited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PointsOfInterest")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Rate")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DestinationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.ToTable("AllEvents");
                });

            modelBuilder.Entity("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Destination", b =>
                {
                    b.HasOne("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Events", b =>
                {
                    b.HasOne("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Destination", "Destination")
                        .WithMany("EventsList")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models.Destination", b =>
                {
                    b.Navigation("EventsList");
                });
#pragma warning restore 612, 618
        }
    }
}
