using Microsoft.EntityFrameworkCore.Migrations;
using SentinelAML.Domain.Constants;

#nullable disable

namespace SentinelAML.Infrastructure.Migrations {
    /// <inheritdoc />
    public partial class DictionaryData : Migration {
        private static readonly string[] columns = new[] { "Name", "Value", "Dict",  "Type" };

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.InsertData(
                table: "Dictionaries",
                columns: columns,
                values: new object[,] {
                    { "color", "red", "user_data", (int) DictionaryType.Value },
                    { "html", "{\"color\":\"red\", \"name\":\"aaa\"}", "user_data", (int) DictionaryType.Object }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {

        }
    }
}
