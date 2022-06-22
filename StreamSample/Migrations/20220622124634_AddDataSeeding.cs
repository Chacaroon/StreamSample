using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamSample.Migrations
{
    public partial class AddDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoLists_TodoListId",
                table: "TodoItem");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "TodoItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "Name", "Tags" },
                values: new object[] { 1, "Backend", "[\"Create data structure\",\"Add validation based on attributes\"]" });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "Name", "Tags" },
                values: new object[] { 2, "Frontend", "[\"Convert a data structire to the FormGroup\",\"Add validation\"]" });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 1, false, "Create control models", 1 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 2, false, "Create and test a FormControl strategy", 1 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 3, false, "Create and test a FormGroup strategy", 1 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 4, false, "Create and test a FormArray strategy", 1 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 5, false, "Pass created data structure to the frontend", 1 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 6, false, "Create the FormBuilder class", 2 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 7, false, "Build a FormGroup based on an obtained data structure", 2 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 8, false, "Add validation to FormControls", 2 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 9, false, "Extend the FormArray in order to push new elements", 2 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Done", "Name", "TodoListId" },
                values: new object[] { 10, false, "Replace the manually created FormGroup with generated one", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoLists_TodoListId",
                table: "TodoItem",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoLists_TodoListId",
                table: "TodoItem");

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "TodoItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoLists_TodoListId",
                table: "TodoItem",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id");
        }
    }
}
