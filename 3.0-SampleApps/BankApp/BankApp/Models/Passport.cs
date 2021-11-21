using System;

namespace BankApp.Models
{

    public class Passport : IEquatable<Passport>
    {
        public long? Number { get; }

        public long? Series { get; }

        public string PlaceOfIssue { get; }

        public DateTime? DateOfIssue { get; }

        public IDivisionCode DivisionCode { get; }

        public Person Holder { get; }

        public Passport(long? series,
                        long? number,
                        string placeOfIssue,
                        DateTime? dateOfIssue,
                        IDivisionCode divisionCode,
                        Person holder)
        {
            if (holder is null)
            {
                throw new ArgumentException("Owner must not be null");
            }

            if (divisionCode is null)
            {
                throw new ArgumentException("Division code must not be null");
            }

            if (string.IsNullOrWhiteSpace(placeOfIssue))
            {
                throw new ArgumentException("Place of issue must not be null");
            }

            if (series <= 0 || number <= 0)
            {
                throw new ArgumentException("Series or number must be a positive integer");
            }

            this.Series = series;
            this.Number = number;
            this.PlaceOfIssue = placeOfIssue;
            this.DateOfIssue = dateOfIssue;
            this.DivisionCode = divisionCode;
            this.Holder = holder;
        }

        public void EditPlaceOfResidence(Address newPlaceOfResidence)
        {
            if (newPlaceOfResidence is null)
            {
                throw new ArgumentException("Place of residence must not be null");
            }

            this.Holder.PlaceOfResidence = newPlaceOfResidence;
        }

        public void EditPlaceOfRegistration(Address newPlaceOfRegistration)
        {
            if (newPlaceOfRegistration is null)
            {
                throw new ArgumentException("Place of registration must not be null");
            }

            this.Holder.PlaceOfRegistration = newPlaceOfRegistration;
        }

        public bool Equals(Passport obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            return this.Number == obj.Number &&
                   this.Series == obj.Series &&
                   this.PlaceOfIssue == obj.PlaceOfIssue &&
                   this.DateOfIssue == obj.DateOfIssue &&
                   this.DivisionCode.Equals(obj.DivisionCode) &&
                   this.Holder.Equals(obj.Holder);
        }
    }
}
