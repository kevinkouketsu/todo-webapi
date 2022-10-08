using TodoWebAPI.Entities;

namespace TodoWebAPI.DTO
{
    public class TodoItemDTO
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; set; }
        public DateTime Created { get; set; }

        public TodoItemDTO(TodoItem todoItem)
        {
            Title = todoItem.Title;
            Description = todoItem.Description;
            Done = todoItem.Done;
            Created = todoItem.Created;
        }
    }
}
