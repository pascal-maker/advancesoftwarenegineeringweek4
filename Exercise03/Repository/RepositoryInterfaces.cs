using System.Runtime.CompilerServices;
using Students.Management.Library.Models;


namespace Howest.Week04.Repositories;

public interface IFileRepository
{
    List<Beer> GetBeers();
    
    void GetBeers(Beer beer);
    void AddBeer ( Beer beer);
    void GetBeerByNr ( Beer beer);
    
}