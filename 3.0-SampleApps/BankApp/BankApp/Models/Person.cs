using System;
using BankApp.Enums;

namespace BankApp.Models
{
    public class Person : IEquatable<Person>
    {
        public string Surname { get; }

        public string Name { get; }

        public Gender Gender { get; }

        public DateTime? Birthday { get; }

        public string PlaceOfBirth { get; }

        public Address PlaceOfResidence { get; set; }

        public Address PlaceOfRegistration { get; set; }

        public Person(string surname,
                      string name,
                      Gender gender,
                      DateTime? birthday,
                      string placeOfBirth,
                      Address placeOfResidence,
                      Address placeOfRegistration = null)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentException("Surname must not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name must not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(placeOfBirth))
            {
                throw new ArgumentException("Place of birth must not be null or empty");
            }

            if (placeOfResidence is null)
            {
                throw new ArgumentNullException("Place of residence must not be null");
            }

            this.Surname = surname;
            this.Name = name;
            this.Gender = gender;
            this.Birthday = birthday;
            this.PlaceOfBirth = placeOfBirth;
            this.PlaceOfResidence = placeOfResidence;
            this.PlaceOfRegistration = placeOfRegistration;
        }

        public bool Equals(Person obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (this == obj)
            {
                return true;
            }

            return this.Surname == obj.Surname &&
                   this.Name == obj.Name &&
                   this.Gender == obj.Gender &&
                   this.Birthday == obj.Birthday &&
                   this.PlaceOfBirth == obj.PlaceOfBirth &&
                   this.PlaceOfResidence.Equals(obj.PlaceOfResidence) &&
                   this.PlaceOfRegistration.Equals(obj.PlaceOfRegistration);
        }
    }
}
