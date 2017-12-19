﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using vega.Persistence;

namespace Vega.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    [Migration("20171213204528_Reservations")]
    partial class Reservations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vega.Core.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("vega.Core.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("vega.Core.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("vega.Core.Models.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ParkingLot");
                });

            modelBuilder.Entity("vega.Core.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("vega.Core.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("Finished");

                    b.Property<string>("Fuel");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ParkingLotId");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("ReturnDate");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("TakeDate");

                    b.Property<int>("VehicleId");

                    b.Property<bool>("Washed");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLotId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("vega.Core.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("vega.Core.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Consumption");

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(255);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<double>("Cost");

                    b.Property<DateTime>("DateOfManufacture");

                    b.Property<bool>("IsRegistered");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ModelId");

                    b.Property<int>("ParkingLotId");

                    b.Property<string>("Places")
                        .IsRequired();

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("ParkingLotId");

                    b.HasIndex("StateId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("vega.Core.Models.VehicleFeature", b =>
                {
                    b.Property<int>("VehicleId");

                    b.Property<int>("FeatureId");

                    b.HasKey("VehicleId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("VehicleFeatures");
                });

            modelBuilder.Entity("vega.Core.Models.Model", b =>
                {
                    b.HasOne("vega.Core.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("vega.Core.Models.Photo", b =>
                {
                    b.HasOne("vega.Core.Models.Vehicle")
                        .WithMany("Photos")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("vega.Core.Models.Reservation", b =>
                {
                    b.HasOne("vega.Core.Models.ParkingLot", "ParkingLot")
                        .WithMany()
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vega.Core.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("vega.Core.Models.Vehicle", b =>
                {
                    b.HasOne("vega.Core.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vega.Core.Models.ParkingLot", "ParkingLot")
                        .WithMany()
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vega.Core.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("vega.Core.Models.VehicleFeature", b =>
                {
                    b.HasOne("vega.Core.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vega.Core.Models.Vehicle", "Vehicle")
                        .WithMany("Features")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
