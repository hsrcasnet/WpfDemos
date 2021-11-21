using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using BankApp.Models;
using Newtonsoft.Json;

namespace BankApp.Services
{
    public class FileIOService : IFileIOService<IList<IDepartment>>
    {
        public void SaveAsJSON(string pathFile, IList<IDepartment> data)
        {
            using (var writer = new StreamWriter(pathFile, false))
            {
                var output = JsonConvert.SerializeObject(data, Formatting.Indented);
                writer.Write(output);
            }
        }

        public IList<IDepartment> OpenAsJSON(string pathFile)
        {
            using (var reader = File.OpenText(pathFile))
            {
                var fileTaxt = reader.ReadToEnd();
                var dataTemp = JsonConvert.DeserializeObject<ObservableCollection<JsonDepartment>>(fileTaxt);
                var departments = this.ConverterDepartments(dataTemp);

                var i = 0;

                foreach (var item in dataTemp)
                {
                    if (item.BankCustomers != null && item.BankCustomers.Count != 0)
                    {
                        departments[i].BankCustomers = this.ConverterBankCustomers(item.BankCustomers);

                        var k = 0;
                        foreach (var p in item.BankCustomers)
                        {
                            if (p.DepositoryAccounts != null && p.DepositoryAccounts.Count != 0)
                            {
                                departments[i].BankCustomers[k].DepositoryAccounts = this.ConverterDepositoryAccount(p.DepositoryAccounts);
                            }

                            k++;
                        }
                    }
                    i++;
                }

                return departments;
            }
        }

        private IList<IDepartment> ConverterDepartments(ObservableCollection<JsonDepartment> data)
        {
            if (data is null)
            {
                return null;
            }

            var departments = new ObservableCollection<IDepartment>();
            foreach (var item in data)
            {
                var department = new Department(item.Id, item.Name, item.StatusDepartment);
                departments.Add(department);
            }

            return departments;
        }

        private IList<IBankCustomer> ConverterBankCustomers(ObservableCollection<JsonBankCustomer> data)
        {
            if (data is null)
            {
                return null;
            }

            var bankCustomers = new ObservableCollection<IBankCustomer>();
            foreach (var item in data)
            {
                var placeOfResidence = new Address(item.Passport.Holder.PlaceOfResidence.RegistrationDate,
                                                       item.Passport.Holder.PlaceOfResidence.Region,
                                                       item.Passport.Holder.PlaceOfResidence.City,
                                                       item.Passport.Holder.PlaceOfResidence.Street,
                                                       item.Passport.Holder.PlaceOfResidence.HouseNumber,
                                                       item.Passport.Holder.PlaceOfResidence.ApartmentNumber,
                                                       item.Passport.Holder.PlaceOfResidence.Housing,
                                                       item.Passport.Holder.PlaceOfResidence.District);

                Address placeOfRegistration = null;
                if (item.Passport.Holder.PlaceOfRegistration != null)
                {
                    placeOfRegistration = new Address(item.Passport.Holder.PlaceOfRegistration.RegistrationDate,
                                                      item.Passport.Holder.PlaceOfRegistration.Region,
                                                      item.Passport.Holder.PlaceOfRegistration.City,
                                                      item.Passport.Holder.PlaceOfRegistration.Street,
                                                      item.Passport.Holder.PlaceOfRegistration.HouseNumber,
                                                      item.Passport.Holder.PlaceOfRegistration.ApartmentNumber,
                                                      item.Passport.Holder.PlaceOfRegistration.Housing,
                                                      item.Passport.Holder.PlaceOfRegistration.District);
                }

                var person = new Person(item.Passport.Holder.Surname,
                                           item.Passport.Holder.Name,
                                           item.Passport.Holder.Gender,
                                           item.Passport.Holder.Birthday,
                                           item.Passport.Holder.PlaceOfBirth,
                                           placeOfResidence,
                                           placeOfRegistration);

                var passport = new Passport(item.Passport.Series,
                                                 item.Passport.Number,
                                                 item.Passport.PlaceOfIssue,
                                                 item.Passport.DateOfIssue,
                                                 item.Passport.DivisionCode,
                                                 person);

                var bankCustomer = new BankCustomer(item.Id,
                                                             passport,
                                                             item.ClientStatus,
                                                             item.Reliability,
                                                             item.PhoneNumber,
                                                             item.Email);

                bankCustomers.Add(bankCustomer);
            }

            return bankCustomers;
        }

        private IList<IDepositoryAccount> ConverterDepositoryAccount(ObservableCollection<DepositoryAccount> data)
        {
            if (data is null)
            {
                return null;
            }

            var depositoryAccounts = new ObservableCollection<IDepositoryAccount>();
            foreach (var item in data)
            {
                depositoryAccounts.Add(item);
            }

            return depositoryAccounts;
        }

    }
}
