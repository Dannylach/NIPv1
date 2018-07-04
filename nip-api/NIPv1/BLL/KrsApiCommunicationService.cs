using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using NIPv1.BLL_Interfaces;
using NIPv1.Models;
using NIPv1.Utilities;
using NIPv1.Validators;

namespace NIPv1.BLL
{
    public class KrsApiCommunicationService : IKrsApiCommunicationService
    {
        private const string Url = "https://api-v3.mojepanstwo.pl/dane/krs_podmioty.json?conditions[krs_podmioty.{0}]={1}";

        private enum NumberType
        {
            [StringValue("nip")]
            nip = 0,
            [StringValue("krs")]
            krs = 1,
            [StringValue("regon")]
            regon = 2
        }

        private CompanyJsonModel GetByIdAsync(HttpClient client, string id, NumberType data)
        {
            var st = String.Format(Url, data, id);
            var response = client.GetAsync(String.Format(Url, data, id)).Result;
            var result = response.Content;
            return new CompanyJsonModel(result.ReadAsStringAsync().Result);
        }

        private CompanyJsonModel GetByNipAsync(HttpClient client, string id)
        {
            return GetByIdAsync(client, id, NumberType.nip);
        }

        private CompanyJsonModel GetByKrsAsync(HttpClient client, string id)
        {
            return GetByIdAsync(client, id, NumberType.krs);
        }

        private CompanyJsonModel GetByRegonAsync(HttpClient client, string id)
        {
            return GetByIdAsync(client, id, NumberType.regon);
        }

        public CompanyModel GetCompanyById(string id)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(1);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var company = new CompanyJsonModel();
                    switch (NipRegonValidator.IsValid(id))
                    {
                        case (int)NumberType.nip:
                            company = GetByNipAsync(client, id);
                            break;
                        case (int)NumberType.krs:
                            company = GetByRegonAsync(client, id);
                            break;
                        case (int)NumberType.regon:
                            company = GetByKrsAsync(client, id);
                            break;
                    }
                    return Mapper.Map<CompanyModel>(company);
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }
    }
}