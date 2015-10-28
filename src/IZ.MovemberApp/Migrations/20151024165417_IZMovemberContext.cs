using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace IZ.MovemberApp.Migrations
{
    public partial class IZMovemberContext : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column(type: "int", nullable: false),
                    FirstName = table.Column(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });
            migration.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false),
                    AuthorId = table.Column(type: "int", nullable: false),
                    Description = table.Column(type: "nvarchar(max)", nullable: true),
                    Image = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Author_AuthorId",
                        columns: x => x.AuthorId,
                        referencedTable: "Author",
                        referencedColumn: "AuthorId");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Author");
            migration.DropTable("Post");
        }
    }
}
