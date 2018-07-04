using Newtonsoft.Json.Linq;

namespace NIPv1.Models
{
    public class CompanyJsonModel
    {
        /// <summary>
        /// Gets data from json and inpts them into class fields
        /// </summary>
        /// <param name="json"></param>
        public CompanyJsonModel(string json)
        {
            JObject jObject = JObject.Parse(json);
            var Count = (string) jObject["Count"];
            if (Count == "1")
            {
                JToken jData = jObject["Dataobject"][0]["data"];
                Regon = (string) jData["krs_podmioty.regon"];
                if (Regon == "0") Regon = "Nieznany numer REGON.";
                Name = (string) jData["krs_podmioty.nazwa_skrocona"];
                Street = (string) jData["krs_podmioty.adres_ulica"];
                HouseNumber = (string) jData["krs_podmioty.adres_numer"];
                PostalCode = (string) jData["krs_podmioty.adres_kod_pocztowy"];
                City = (string) jData["krs_podmioty.adres_miejscowosc"];
                Krs = (string) jData["krs_podmioty.krs"];
                Nip = (string) jData["krs_podmioty.nip"];
                if (Nip == "0") Nip = "Nieznany numer NIP.";
                Rating = 0;
            }
        }

        /// <summary>
        /// Default constructor, makes all to null.
        /// </summary>
        public CompanyJsonModel()
        {
            Regon = null;
            Name = null;
            Street = null;
            HouseNumber = null;
            PostalCode = null;
            City = null;
            Krs = null;
            Nip = null;
            Rating = 0;

        }

        public int Id { get; set; }

        public string Regon { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Krs { get; set; }

        public string Nip { get; set; }

        public int Rating { get; set; }
    }
}