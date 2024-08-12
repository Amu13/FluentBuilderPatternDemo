using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderExampleLogic
{
    public class AddressBuilder
    {
        public string _street;
        public string _city;
        public string _postalCode;
        public string _country;
        public AddressBuilder() { }
        public static AddressBuilder Empty() => new();

        public AddressBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }

        public AddressBuilder WithCity(string city) 
        {  _city = city; return this; }

        public AddressBuilder WithPostalCode(string postalCode)
        { _postalCode = postalCode; return this; }

        public AddressBuilder WithCountry(string country) {  _country = country; return this; }

        public Address Build()
        {
            return new()
            {
                Street = _street,
                City = _city,
                PostalCode = _postalCode,
                Country = _country
            };
        }

    }
}
