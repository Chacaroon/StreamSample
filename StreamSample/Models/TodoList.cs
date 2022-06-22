namespace StreamSample.Models;

public class TodoList
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string[] Tags { get; set; }

    public ICollection<TodoItem> Items { get; set; }
}
