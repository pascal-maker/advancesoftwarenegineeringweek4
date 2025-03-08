namespace MediaPlatform.Models
{
    public class Podcast : Media
    {
        public int NumberOfEpisodes { get; set; }
        public string Host { get; set; } = string.Empty;

        public Podcast(string title, int numberOfEpisodes, string host)
            : base(title)
        {
            NumberOfEpisodes = numberOfEpisodes;
            Host = host;
        }

        // For object initializer if needed
        public Podcast() { }

        public override string ToString()
        {
            return $"[Podcast] Title: {Title}, Episodes: {NumberOfEpisodes}, Host: {Host}";
        }
    }
}
