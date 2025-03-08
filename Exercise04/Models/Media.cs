namespace MediaPlatform.Models
{
    public abstract class Media
    {
        public string Title { get; set; } = string.Empty;

        // Protected constructor so only derived classes can instantiate
        protected Media(string title)
        {
            Title = title;
        }

        // For usage by JSON libraries, object initializers, etc.
        protected Media() { }
    }
}
