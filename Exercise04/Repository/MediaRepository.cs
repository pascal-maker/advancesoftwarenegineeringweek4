using System.Collections.Generic;
using System.Linq;
using MediaPlatform.Models;

namespace MediaPlatform.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        // In-memory "database"
        private static readonly List<Media> _storage = new();

        public void Add(Media media)
        {
            _storage.Add(media);
        }

        public Media? Get(string title)
        {
            return _storage.FirstOrDefault(m => m.Title.Equals(title, System.StringComparison.OrdinalIgnoreCase));
        }

        public List<Media> GetAll()
        {
            return _storage.ToList(); // return a copy
        }
    }
}
