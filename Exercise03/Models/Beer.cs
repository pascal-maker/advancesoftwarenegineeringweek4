using System;
using Beers.Management.Library.Exceptions;

namespace Beers.Management.Library.Models
{
    public class Beer
    {
        private string _naam = string.Empty;
        private string _brouwerij = string.Empty;
        private string _kleur = string.Empty;
        private float _alcohol;

        public int Nr { get; set; }

        public string Naam
        {
            get => _naam;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BeerException("Naam", 0f, "Name cannot be null or empty");
                }
                _naam = value;
            }
        }

        public string Brouwerij
        {
            get => _brouwerij;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BeerException("Brouwerij", 0f, "Brewery cannot be null or empty");
                }
                _brouwerij = value;
            }
        }

        public string Kleur
        {
            get => _kleur;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BeerException("Kleur", 0f, "Color cannot be null or empty");
                }
                _kleur = value;
            }
        }

        public float Alcohol
        {
            get => _alcohol;
            set
            {
                if (value < 0)
                {
                    throw new BeerException("Alcohol", value, "Alcoholpercentage cannot be negative");
                }
                _alcohol = value;
            }
        }

        // Paramless constructor for CSVHelper or object initializers
        public Beer()
        {
        }

        // Full constructor if needed
        public Beer(int nr, string naam, string brouwerij, string kleur, float alcohol)
        {
            Nr = nr;
            Naam = naam;
            Brouwerij = brouwerij;
            Kleur = kleur;
            Alcohol = alcohol;
        }

        public override string ToString()
        {
            return $"{Nr}, {Naam}, {Brouwerij}, {Kleur}, {Alcohol}%";
        }
    }
}
