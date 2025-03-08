using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Beers.Management.Library.Models;

namespace Beers.Management.Library.Repositories
{
    public class CsvFileRepository : IFileRepository
    {
        private const string BeersFile = "csvfiles/bieren.txt"; // Or "csvfiles/bieren.txt" if needed

        public List<Beer> GetBeers()
        {
            if (!File.Exists(BeersFile)) 
                return new List<Beer>();

            using var reader = new StreamReader(BeersFile);
            // If first line has no header, keep HasHeaderRecord=false
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using var csv = new CsvReader(reader, config);

            // This automatically maps columns to Beer properties in the order: Nr,Naam,Brouwerij,Kleur,Alcohol
            return csv.GetRecords<Beer>().ToList();
        }

        public Beer? GetBeerByNr(int nr)
        {
            return GetBeers().FirstOrDefault(b => b.Nr == nr);
        }

        public void AddBeer(Beer beer)
        {
            var beers = GetBeers();
            // Just auto-assign a new Nr if desired:
            beer.Nr = beers.Any() ? beers.Max(b => b.Nr) + 1 : 1;
            beers.Add(beer);

            // Overwrite file with updated list
            using var writer = new StreamWriter(BeersFile);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using var csv = new CsvWriter(writer, config);
            csv.WriteRecords(beers);
        }
    }
}
