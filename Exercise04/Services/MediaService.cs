using System.Collections.Generic;
using MediaPlatform.Models;
using MediaPlatform.Repositories;

namespace MediaPlatform.Services
{
    public class MediaService
    {
        private readonly IMediaRepository _repository;

        public MediaService(IMediaRepository repository)
        {
            _repository = repository;
        }

        public void AddMedia(Media media)
        {
            // Additional business rules could go here
            _repository.Add(media);
        }

        public Media? GetMedia(string title)
        {
            return _repository.Get(title);
        }

        public List<Media> GetAllMedia()
        {
            return _repository.GetAll();
        }
    }
}
