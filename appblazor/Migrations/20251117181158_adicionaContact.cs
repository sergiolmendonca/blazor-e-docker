using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appblazor.Migrations
{
    /// <inheritdoc />
    public partial class adicionaContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 2, "teste@teste", "Ailone" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
