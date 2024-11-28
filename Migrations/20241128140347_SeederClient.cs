using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManager.Migrations
{
    /// <inheritdoc />
    public partial class SeederClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Domingos", "u12345" },
                    { Guid.NewGuid(), "Teste", "123456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Name",
                keyValues:  new object[]
                {
                    "Domingos" ,
                    "Teste" 
                });
        }
    }
}
