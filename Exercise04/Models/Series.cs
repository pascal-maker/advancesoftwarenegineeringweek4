namespace MediaPlatform.Models
{
    public class Series : Media
    {
        public int NumberOfEpisodes { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;

        public Series(string title, int numberOfEpisodes, string genre, string creator)
            : base(title)
        {
            NumberOfEpisodes = numberOfEpisodes;
            Genre = genre;
            Creator = creator;
        }

        // For object initializer if needed
        public Series() { }

        public override string ToString()
        {
            return $"[Series] Title: {Title}, Episodes: {NumberOfEpisodes}, Genre: {Genre}, Creator: {Creator}";
        }
    }
}
