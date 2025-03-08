namespace MediaPlatform.Models
{
    public class Movie : Media
    {
        public int Duration { get; set; }  // Duration in minutes
        public string Genre { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;

        public Movie(string title, int duration, string genre, string director)
            : base(title)
        {
            Duration = duration;
            Genre = genre;
            Director = director;
        }

        // For object initializer if needed
        public Movie() { }
        
        public override string ToString()
        {
            return $"[Movie] Title: {Title}, Duration: {Duration} min, Genre: {Genre}, Director: {Director}";
        }
    }
}
