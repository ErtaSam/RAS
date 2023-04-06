using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAddressFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(128)",
                nullable: false,
                defaultValue: "");
        }
    }
}
