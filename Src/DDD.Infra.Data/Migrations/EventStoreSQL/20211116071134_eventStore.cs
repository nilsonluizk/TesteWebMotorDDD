using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDD.Infra.Data.Migrations.EventStoreSql
{
    public partial class eventStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoredEvent",
                columns: table => new
                {
                    Id = table.Column<System.Guid>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Action = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredEvent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
