using MediaPlatform.Models;

namespace MediaPlatform.Factory
{
    public static class MediaFactory
    {
        // Overloaded methods to create each media type.
        public static Movie CreateMovie(string title, int duration, string genre, string director)
        {
            return new Movie(title, duration, genre, director);
        }

        public static Series CreateSeries(string title, int numberOfEpisodes, string genre, string creator)
        {
            return new Series(title, numberOfEpisodes, genre, creator);
        }

        public static Podcast CreatePodcast(string title, int numberOfEpisodes, string host)
        {
            return new Podcast(title, numberOfEpisodes, host);
        }

        // Alternatively, a single method with a switch on MediaType
        public static Media CreateMedia(MediaType type, string title, int num1, string str1, string str2 = "")
        {
            switch (type)
            {
                case MediaType.Movie:
                    // interpret num1 as "duration"
                    // str1 as "genre", str2 as "director"
                    return new Movie(title, num1, str1, str2);
                case MediaType.Series:
                    // interpret num1 as "numberOfEpisodes"
                    // str1 as "genre", str2 as "creator"
                    return new Series(title, num1, str1, str2);
                case MediaType.Podcast:
                    // interpret num1 as "numberOfEpisodes"
                    // str1 as "host"
                    return new Podcast(title, num1, str1);
                default:
                    throw new System.ArgumentException($"Unsupported MediaType: {type}");
            }
        }
    }
}
