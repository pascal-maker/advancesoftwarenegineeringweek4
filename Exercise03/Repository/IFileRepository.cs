using System.Collections.Generic;
using Beers.Management.Library.Models;

namespace Beers.Management.Library.Repositories
{
    public interface IFileRepository
    {
        List<Beer> GetBeers();
        Beer? GetBeerByNr(int nr);
        void AddBeer(Beer beer);
    }
}
