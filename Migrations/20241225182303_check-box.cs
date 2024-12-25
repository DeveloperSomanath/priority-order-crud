using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeBlazorCRUD.Migrations
{
    /// <inheritdoc />
    public partial class checkbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Employees");
        }
    }
}
