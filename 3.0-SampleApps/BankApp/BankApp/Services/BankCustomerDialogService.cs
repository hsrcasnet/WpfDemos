using System;
using System.Collections.Generic;
using BankApp.Enums;
using BankApp.Models;
using BankApp.Views;

namespace BankApp.Services
{
    public class BankCustomerDialogService : IBankCustomerDialogService
    {
        public IBankCustomer Create(Status clientStatus)
        {
            var dialog = new AddBankCustomersWindow();

            if (dialog.ShowDialog() != true)
            {
                return null;
            }

            return this.CreateBankCustomer(dialog, clientStatus);
        }

        public IBankCustomer Edit(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
            {
                throw new ArgumentNullException("Bank customer must not be null");
            }

            var dialog = new AddBankCustomersWindow();

            FillInWindows(dialog, bankCustomer);

            if (dialog.ShowDialog() != true)
            {
                return null;
            }

            var tempBankCustomer = this.CreateBankCustomer(dialog, bankCustomer.ClientStatus);
            tempBankCustomer.Id = bankCustomer.Id;
            tempBankCustomer.DepositoryAccounts = bankCustomer.DepositoryAccounts;

            return tempBankCustomer;
        }

        public IBankCustomer Selected(IList<IBankCustomer> entities)
        {
            throw new NotImplementedException();
        }

        private IBankCustomer CreateBankCustomer(AddBankCustomersWindow dialog,
                                                 Status clientStatus)
        {
            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            var residenceAddress = this.CreateAddress(dialog.RegistrationDatePlaceOfResidence,
                                                 dialog.RegionPlaceOfResidence,
                                                 dialog.CityPlaceOfResidence,
                                                 dialog.StreetPlaceOfResidence,
                                                 dialog.HouseNumberPlaceOfResidence,
                                                 dialog.ApartmentNumberPlaceOfResidence,
                                                 dialog.HousingPlaceOfResidence,
                                                 dialog.DistrictPlaceOfResidence);

            if (residenceAddress is null)
            {
                return null;
            }

            var registrationAddress = this.CreateAddress(dialog.RegistrationDateRegistration,
                                                    dialog.RegionRegistration,
                                                    dialog.CityRegistration,
                                                    dialog.StreetRegistration,
                                                    dialog.HouseNumberRegistration,
                                                    dialog.ApartmentNumberRegistration,
                                                    dialog.HousingRegistration,
                                                    dialog.DistrictRegistration);

            var persone = this.CreatePerson(dialog.SurnameBankCustomer,
                                        dialog.NameBankCustomer,
                                        dialog.GenderBankCustomer,
                                        dialog.BirthdayBankCustomer,
                                        dialog.PlaceOfBirthBankCustomer,
                                        residenceAddress,
                                        registrationAddress);

            if (persone is null)
            {
                return null;
            }

            var divisionCode = this.CreateDivisionCode(dialog.DivisionCodeLeftPassport,
                                                  dialog.DivisionCodeRightPassport);

            if (divisionCode is null)
            {
                return null;
            }

            var passport = this.CreatePassport(dialog.SeriesPassport,
                                          dialog.NumberPassport,
                                          dialog.PlaceOfIssuePassport,
                                          dialog.DateOfIssuePassport,
                                          divisionCode,
                                          persone);

            if (passport is null)
            {
                return null;
            }

            return new BankCustomer(0,
                                    passport,
                                    clientStatus,
                                    dialog.Reliability,
                                    dialog.PhoneNumber,
                                    dialog.Email);
        }

        private static void FillInWindows(AddBankCustomersWindow dialog,
                                   IBankCustomer bankCustomer)
        {
            if (dialog is null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (bankCustomer is null)
            {
                throw new ArgumentNullException(nameof(bankCustomer));
            }

            dialog.PhoneNumber = bankCustomer.PhoneNumber;
            dialog.Email = bankCustomer.Email;
            dialog.Description = bankCustomer.Description;
            dialog.Reliability = bankCustomer.Reliability;

            dialog.NameBankCustomer = bankCustomer.Passport.Holder.Name;
            dialog.SurnameBankCustomer = bankCustomer.Passport.Holder.Surname;
            dialog.BirthdayBankCustomer = bankCustomer.Passport.Holder.Birthday;
            dialog.GenderBankCustomer = bankCustomer.Passport.Holder.Gender;
            dialog.PlaceOfBirthBankCustomer = bankCustomer.Passport.Holder.PlaceOfBirth;

            dialog.SeriesPassport = bankCustomer.Passport.Series;
            dialog.NumberPassport = bankCustomer.Passport.Number;
            dialog.DivisionCodeLeftPassport = bankCustomer.Passport.DivisionCode.Left;
            dialog.DivisionCodeRightPassport = bankCustomer.Passport.DivisionCode.Right;
            dialog.DateOfIssuePassport = bankCustomer.Passport.DateOfIssue;
            dialog.PlaceOfIssuePassport = bankCustomer.Passport.PlaceOfIssue;

            dialog.RegionPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.Region;
            dialog.CityPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.City;
            dialog.DistrictPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.District;
            dialog.StreetPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.Street;
            dialog.HouseNumberPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.HouseNumber;
            dialog.HousingPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.Housing;
            dialog.ApartmentNumberPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.ApartmentNumber;
            dialog.RegistrationDatePlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.RegistrationDate;

            if (bankCustomer.Passport.Holder.PlaceOfRegistration != null)
            {
                dialog.RegionRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.Region;
                dialog.CityRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.City;
                dialog.DistrictRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.District;
                dialog.StreetRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.Street;
                dialog.HouseNumberRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.HouseNumber;
                dialog.HousingRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.Housing;
                dialog.ApartmentNumberRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.ApartmentNumber;
                dialog.RegistrationDateRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.RegistrationDate;
            }
        }

        private Address CreateAddress(DateTime? registrationDate,
                                       string region,
                                       string city,
                                       string street,
                                       int? houseNumber,
                                       int? apartmentNumber,
                                       string housing,
                                       string district)
        {
            try
            {
                return new Models.Address(registrationDate,
                                   region,
                                   city,
                                   street,
                                   houseNumber,
                                   apartmentNumber,
                                   housing,
                                   district);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Person CreatePerson(string surname, string name, Gender gender, DateTime? birthday, string placeOfBirth, Address placeOfResidence, Address placeOfRegistration)
        {
            try
            {
                return new Person(surname, name, gender, birthday, placeOfBirth, placeOfResidence, placeOfRegistration);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Passport CreatePassport(long? series, long? number, string placeOfIssue, DateTime? dateOfIssue, IDivisionCode divisionCode, Person holder)
        {
            try
            {
                return new Passport(series,
                                    number,
                                    placeOfIssue,
                                    dateOfIssue,
                                    divisionCode,
                                    holder);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IDivisionCode CreateDivisionCode(int? left, int? right)
        {
            try
            {
                return new DivisionCode(left, right);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
