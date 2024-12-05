using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFriends.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 25, "John Doe" },
                    { 2, 30, "Jane Smith" },
                    { 3, 45, "Michael Johnson" },
                    { 4, 22, "Emily Davis" },
                    { 5, 34, "David Wilson" },
                    { 6, 28, "Sarah Brown" },
                    { 7, 33, "Chris Evans" },
                    { 8, 27, "Olivia Martinez" },
                    { 9, 24, "Liam Lee" },
                    { 10, 29, "Sophia Harris" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
