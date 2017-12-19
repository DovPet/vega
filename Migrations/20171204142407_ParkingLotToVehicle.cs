using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class ParkingLotToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingLotId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ParkingLotId",
                table: "Vehicles",
                column: "ParkingLotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_ParkingLot_ParkingLotId",
                table: "Vehicles",
                column: "ParkingLotId",
                principalTable: "ParkingLot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_ParkingLot_ParkingLotId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ParkingLotId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ParkingLotId",
                table: "Vehicles");
        }
    }
}
