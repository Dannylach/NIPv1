using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NIPv1.Models;

namespace NIPv1.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var data = new List<Data>()
            {
                new Data {CompanyId=1,PostalCode = "64-980", KRS = "7711771177", City = "Trzcianka", Name = "Jakas firma", NIP = "7777777777", REGON = "3243223443", HouseNumber = "11", Street = "Sikorskiego"},
                new Data {CompanyId=2,PostalCode = "98-600", KRS = "1345678945", City = "Czarnków", Name = "v2 firma", NIP = "3212321111", REGON = "2222233332", HouseNumber = "11", Street = "Sikorskiego"},
                new Data {CompanyId=3,PostalCode = "56-321", KRS = "7894569878", City = "Poznań", Name = "fajna firma", NIP = "1949791949", REGON = "0121321313", HouseNumber = "11", Street = "Sikorskiego"},
                new Data {CompanyId=4,PostalCode = "60-100", KRS = "7715464578", City = "Kraków", Name = "magiczna firma", NIP = "3576892415", REGON = "0321432141", HouseNumber = "11", Street = "Sikorskiego"}
            };
            data.ForEach(s => context.Datas.Add(s));
            context.SaveChanges();
        }
    }
}