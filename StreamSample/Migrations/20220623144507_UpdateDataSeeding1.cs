using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamSample.Migrations
{
    public partial class UpdateDataSeeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Create and test a FromValue attribute");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "TodoListId" },
                values: new object[] { "Implement and test valiadtors processing logic", 1 });

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "TodoListId" },
                values: new object[] { "Pass the created data structure to the frontend", 1 });

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Create the FormBuilder class");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Build a FormGroup based on an obtained data structure");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Add validation to FormControls");

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 12, false, "Extend the FormArray in order to push new elements", 2 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 13, false, "Replace the manually created FormGroup with the generated one", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Pass created data structure to the frontend");

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "TodoListId" },
                values: new object[] { "Create the FormBuilder class", 2 });

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "TodoListId" },
                values: new object[] { "Build a FormGroup based on an obtained data structure", 2 });

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

            migrationBuilder.UpdateData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Replace the manually created FormGroup with generated one");
        }
    }
}
