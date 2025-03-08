using System.Collections.Generic;
using MediaPlatform.Models;

namespace MediaPlatform.Repositories
{
    public interface IMediaRepository
    {
        void Add(Media media);
        Media? Get(string title);
        List<Media> GetAll();
    }
}
