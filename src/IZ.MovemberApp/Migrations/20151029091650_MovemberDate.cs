using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace IZ.MovemberApp.Migrations
{
    public partial class MovemberDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Post",
                nullable: false);
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Date", table: "Post");
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Post",
                nullable: true);
        }
    }
}
