using System.Collections.Generic;
using Beers.Management.Library.Models;
using Beers.Management.Library.Repositories;

namespace Beers.Management.Library.Services
{
    public class BeersService
    {
        private readonly IFileRepository _repo;

        public BeersService(IFileRepository repo)
        {
            _repo = repo;
        }

        public List<Beer> GetBeers()
        {
            return _repo.GetBeers();
        }

        public Beer? GetBeerByNr(int nr)
        {
            return _repo.GetBeerByNr(nr);
        }

        public void AddBeer(Beer beer)
        {
            _repo.AddBeer(beer);
        }
    }
}
