using System;

namespace BankApp.Models
{
    public class Address : IEquatable<Address>
    {
        public DateTime? RegistrationDate { get; }

        public string Region { get; }

        public string City { get; }

        public string District { get; }

        public string Street { get; }

        public int? HouseNumber { get; }

        public string Housing { get; }

        public int? ApartmentNumber { get; }

        public Address(DateTime? registrationDate,
                       string region,
                       string city,
                       string street,
                       int? houseNumber,
                       int? apartmentNumber = null,
                       string housing = null,
                       string district = null)
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                throw new ArgumentException("Region must not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City must not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentException("Street must not be null or empty");
            }

            if (houseNumber <= 0)
            {
                throw new ArgumentException("House number must be a positive integer");
            }

            this.RegistrationDate = registrationDate;
            this.Region = region;
            this.City = city;
            this.Street = street;
            this.HouseNumber = houseNumber;

            this.ApartmentNumber = apartmentNumber;
            this.Housing = housing;
            this.District = district;
        }

        public bool Equals(Address obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            return this.RegistrationDate == obj.RegistrationDate &&
                   this.Region == obj.Region &&
                   this.City == obj.City &&
                   this.District == obj.District &&
                   this.Street == obj.Street &&
                   this.HouseNumber == obj.HouseNumber &&
                   this.Housing == obj.Housing &&
                   this.ApartmentNumber == obj.ApartmentNumber;
        }
    }
}
