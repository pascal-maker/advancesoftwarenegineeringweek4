using System;
using System.Collections.Generic;
using Beers.Management.Library.Exceptions;
using Beers.Management.Library.Models;
using Beers.Management.Library.Repositories;
using Beers.Management.Library.Services;

class Program
{
    static void Main()
    {
        // 1) Test: Creating a Beer object with correct/incorrect values
        try
        {
            var goodBeer = new Beer(10, "Chimay Bleu", "Chimay", "Donker", 9.0f);
            Console.WriteLine($"Good Beer Created: {goodBeer}");

            // This should throw BeerException for negative Alcohol
            var invalidBeer = new Beer(11, "Test", "BreweryTest", "Blond", -2.0f);
            Console.WriteLine($"Invalid Beer (should not appear): {invalidBeer}");
        }
        catch (BeerException ex)
        {
            Console.WriteLine($"BeerException Caught: {ex.Message}");
            Console.WriteLine($"Wrong Field: {ex.WrongFieldname}, Wrong Value: {ex.WrongValue}");
        }

        // 2) Repository/Service usage
        IFileRepository repo = new CsvFileRepository();
        var service = new BeersService(repo);

        // Read all beers from bieren.txt
        var allBeers = service.GetBeers();
        Console.WriteLine("\n--- Beers from bieren.txt ---");
        if (allBeers.Count == 0) 
        {
            Console.WriteLine("No beers found in file.");
        }
        else
        {
            foreach (var b in allBeers)
            {
                Console.WriteLine(b);
            }
        }

        // Add a new Beer (this will re-write the file)
        try
        {
            var newBeer = new Beer
            {
                // Nr auto-assigned in repository
                Naam = "NewBeer",
                Brouwerij = "NewBrewery",
                Kleur = "Amber",
                Alcohol = 5.5f
            };
            service.AddBeer(newBeer);
            Console.WriteLine("Successfully added new beer to bieren.txt!");
        }
        catch (BeerException ex)
        {
            Console.WriteLine($"Failed to add beer: {ex.Message}");
        }

        // Attempt to get a beer by Nr
        var beerNr = 1; 
        var found = service.GetBeerByNr(beerNr);
        if (found == null) 
            Console.WriteLine($"Beer with Nr={beerNr} not found.");
        else
            Console.WriteLine($"Found Beer with Nr={beerNr}: {found}");
    }
}
