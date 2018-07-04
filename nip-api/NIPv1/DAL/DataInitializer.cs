﻿using System.Collections.Generic;
using NIPv1.Entities;
using NIPv1.Models;

namespace NIPv1.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var Company = new List<CompanyEntity>()
            {
                new CompanyEntity {PostalCode = "64-980", Krs = "7711771177", City = "Trzcianka", Name = "Jakas firma", Nip = "7777777777", Regon = "23511332857188", HouseNumber = "11", Street = "Sikorskiego", Rating = 3},
                new CompanyEntity {PostalCode = "98-600", Krs = "1345678945", City = "Czarnków", Name = "v2 firma", Nip = "8543919243", Regon = "732065814", HouseNumber = "11", Street = "Sikorskiego", Rating = 5},
                new CompanyEntity {PostalCode = "56-321", Krs = "7894569878", City = "Poznań", Name = "fajna firma", Nip = "9819139256", Regon = "123456785", HouseNumber = "11", Street = "Sikorskiego", Rating = 1},
                new CompanyEntity {PostalCode = "60-100", Krs = "7715464578", City = "Kraków", Name = "magiczna firma", Nip = "4438346694", Regon = "12345678512347", HouseNumber = "11", Street = "Sikorskiego", Rating = 2}
            };
            Company.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();
        }
    }
}