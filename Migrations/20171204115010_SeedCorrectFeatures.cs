using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedCorrectFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Feature1', 'Feature2', 'Feature3')");

        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Manual')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Automatic')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Semi-automatic')");

        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Petrol')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Petrol/gas')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Hybrid-Petrol/eletric')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Eletric')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Diesel')");

        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Front-wheel drive')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Rear-wheel drive')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Four-wheel drive')");

        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Sedan')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Wagon')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Hatchback')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('SUV')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Pickup')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Coupe')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Cabrio')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Minivan')");
        
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Navigation/GPS')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Heating seats')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Tow hook')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Cruise control')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Air conditioning')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Leather seats')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Auxhilary heating')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('CD player')");
         migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Hands-free kit')");
        migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Parking assistant')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
