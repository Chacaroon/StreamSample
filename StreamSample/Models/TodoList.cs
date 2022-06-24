using FormBuilder.Attributes;
using System.ComponentModel.DataAnnotations;

namespace StreamSample.Models;

public class TodoList
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [FormValue]
    public string[] Tags { get; set; }

    public ICollection<TodoItem> Items { get; set; }
}
