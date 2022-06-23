using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamSample.Migrations
{
    public partial class UpdateDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Create BaseStrategy");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Create and test a FormControl strategy");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Create and test a FormGroup strategy");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Create and test a FormArray strategy");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "TodoListId" },
                values: new object[] { "Pass created data structure to the frontend", 1 });

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Create the FormBuilder class");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Build a FormGroup based on an obtained data structure");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Add validation to FormControls");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Extend the FormArray in order to push new elements");

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 11, false, "Replace the manually created FormGroup with generated one", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Create and test a FormControl strategy");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Create and test a FormGroup strategy");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Create and test a FormArray strategy");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Pass created data structure to the frontend");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "TodoListId" },
                values: new object[] { "Create the FormBuilder class", 2 });

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Build a FormGroup based on an obtained data structure");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Add validation to FormControls");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Extend the FormArray in order to push new elements");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Replace the manually created FormGroup with generated one");
        }
    }
}
