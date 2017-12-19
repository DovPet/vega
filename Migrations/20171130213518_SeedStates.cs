using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('Available')");
                migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('Reserved')");
                migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('On a service')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql("DELETE FROM States");
        }
    }
}
