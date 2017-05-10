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
                new Data {ID=1,kod_pocztowy = "64-980", KRS = "7711771177", miasto = "Trzcianka", nazwa = "Jakas firma", NIP = "7777777777", REGON = "0000110111", nr_domu = 11, ulica = "Sikorskiego"},
                new Data {ID=2,kod_pocztowy = "98-600", KRS = "1345678945", miasto = "Czarnków", nazwa = "v2 firma", NIP = "1111111111", REGON = "2222233332", nr_domu = 11, ulica = "Sikorskiego"},
                new Data {ID=3,kod_pocztowy = "56-321", KRS = "7894569878", miasto = "Poznań", nazwa = "fajna firma", NIP = "1949791949", REGON = "0121321313", nr_domu = 11, ulica = "Sikorskiego"},
                new Data {ID=4,kod_pocztowy = "60-100", KRS = "7715464578", miasto = "Kraków", nazwa = "magiczna firma", NIP = "3576892415", REGON = "0321432141", nr_domu = 11, ulica = "Sikorskiego"}
            };
            data.ForEach(s => context.Datas.Add(s));
            context.SaveChanges();

            var stat = new List<Stat>()
            {
                new Stat {ID = 1, KRS = "7711771177", NIP = "7777777777", REGON = "0000110111", counter = 0},
                new Stat {ID = 2, KRS = "1345678945", NIP = "1111111111", REGON = "2222233332", counter = 0},
                new Stat {ID = 3, KRS = "7894569878", NIP = "1949791949", REGON = "0121321313", counter = 0},
                new Stat {ID = 4, KRS = "7715464578", NIP = "3576892415", REGON = "0321432141", counter = 0}
            };
            stat.ForEach(s => context.Stats.Add(s));
            context.SaveChanges();
        }
    }
}