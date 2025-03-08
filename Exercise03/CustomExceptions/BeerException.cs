using System;

namespace Beers.Management.Library.Exceptions
{
    public class BeerException : Exception
    {
        public string WrongFieldname { get; }
        public float WrongValue { get; }
        public string AdditionalInfo { get; }

        // Constructor without inner exception
        public BeerException(string wrongFieldname, float wrongValue, string additionalInfo)
            : base($"BeerException: Invalid field '{wrongFieldname}' with value '{wrongValue}'. Info: {additionalInfo}")
        {
            WrongFieldname = wrongFieldname;
            WrongValue = wrongValue;
            AdditionalInfo = additionalInfo;
        }

        // Constructor with inner exception
        public BeerException(string wrongFieldname, float wrongValue, string additionalInfo, Exception innerException)
            : base($"BeerException: Invalid field '{wrongFieldname}' with value '{wrongValue}'. Info: {additionalInfo}", innerException)
        {
            WrongFieldname = wrongFieldname;
            WrongValue = wrongValue;
            AdditionalInfo = additionalInfo;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nWrongFieldName: {WrongFieldname}\nWrongValue: {WrongValue}\nAdditionalInfo: {AdditionalInfo}";
        }
    }
}
