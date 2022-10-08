namespace TodoWebAPI.Entities
{
    public class TodoItem : EntityBase
    {
        private const int MaximumTitleLength = 100;

        public TodoItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException(nameof(title));
            }

            if (title.Length >= MaximumTitleLength)
            {
                throw new ArgumentOutOfRangeException(nameof(title));
            }

            Title = title;
            Created = DateTime.Now;
            Description = string.Empty;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; set; }
        public DateTime Created { get; set; }
    }
}
