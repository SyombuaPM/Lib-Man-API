using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibManApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBookTypeDiscriminator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FileFormat",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Isbn_No",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Books",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "EBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Isbn_No = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EBooks_Books_Id",
                        column: x => x.Id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintedBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileFormat = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintedBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintedBooks_Books_Id",
                        column: x => x.Id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EBooks");

            migrationBuilder.DropTable(
                name: "PrintedBooks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Books",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileFormat",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn_No",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }
    }
}
