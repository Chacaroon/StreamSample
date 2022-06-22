using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StreamSample.Models;
using System.Text.Json;

namespace StreamSample.Context;

public class ApplicationContext : DbContext
{
    public DbSet<TodoList> TodoLists { get; set; }

    public string DbPath { get; }

    public ApplicationContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "todolist.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoList>()
            .Property(t => t.Tags)
            .HasConversion(new ValueConverter<string[], string>(
                v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
                v => JsonSerializer.Deserialize<string[]>(v, null as JsonSerializerOptions)));

        modelBuilder.Entity<TodoList>()
            .HasData(new TodoList
            {
                Id = 1,
                Name = "Backend",
                Tags = new[] { "Create data structure", "Add validation based on attributes" }
            },
            new TodoList
            {
                Id = 2,
                Name = "Frontend",
                Tags = new[] { "Convert a data structire to the FormGroup", "Add validation" },
            });

        modelBuilder.Entity<TodoItem>()
            .HasData(new[]
                {
                    new TodoItem
                    {
                        Id = 6,
                        TodoListId = 2,
                        Name = "Create the FormBuilder class"
                    },
                    new TodoItem
                    {
                        Id = 7,
                        TodoListId = 2,
                        Name = "Build a FormGroup based on an obtained data structure"
                    },
                    new TodoItem
                    {
                        Id = 8,
                        TodoListId = 2,
                        Name = "Add validation to FormControls"
                    },
                    new TodoItem
                    {
                        Id = 9,
                        TodoListId = 2,
                        Name = "Extend the FormArray in order to push new elements"
                    },
                    new TodoItem
                    {
                        Id = 10,
                        TodoListId = 2,
                        Name = "Replace the manually created FormGroup with generated one"
                    },
                    new TodoItem
                    {
                        Id = 1,
                        TodoListId = 1,
                        Name = "Create control models"
                    },
                    new TodoItem
                    {
                        Id = 2,
                        TodoListId = 1,
                        Name = "Create and test a FormControl strategy"
                    },
                    new TodoItem
                    {
                        Id = 3,
                        TodoListId = 1,
                        Name = "Create and test a FormGroup strategy"
                    },
                    new TodoItem
                    {
                        Id = 4,
                        TodoListId = 1,
                        Name = "Create and test a FormArray strategy"
                    },
                    new TodoItem {
                        Id = 5,
                        TodoListId = 1,
                        Name = "Pass created data structure to the frontend"
                    }
                });
    }
}
