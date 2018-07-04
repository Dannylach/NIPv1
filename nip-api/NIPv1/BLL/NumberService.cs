using System;
using AutoMapper;
using NIPv1.BLL_Interfaces;
using NIPv1.DAL_Interfaces;
using NIPv1.Entities;
using NIPv1.Models;
using NIPv1.Validators;

namespace NIPv1.BLL
{
    public class NumberService : INumberService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IKrsApiCommunicationService krsApiCommunicationService;
        private enum NumberType
        {
            nip = 0,
            krs = 1,
            regon = 2
        }

        public NumberService(ICompanyRepository companyRepository, 
                                IKrsApiCommunicationService krsApiCommunicationService)
        {
            this.companyRepository = companyRepository;
            this.krsApiCommunicationService = krsApiCommunicationService;
        }
        
        public CompanyModel GetById(string id)
        {
            try
            {
                var company = new CompanyModel();
                switch (NipRegonValidator.IsValid(id))
                {
                    case (int)NumberType.nip:
                        company = Mapper.Map<CompanyModel>(companyRepository.GetByNip(id));
                        break;
                    case (int)NumberType.krs:
                        company = Mapper.Map<CompanyModel>(companyRepository.GetByKrs(id));
                        break;
                    case (int)NumberType.regon:
                        company = Mapper.Map<CompanyModel>(companyRepository.GetByRegon(id));
                        break;
                }
                if (company == null)
                {
                    company = krsApiCommunicationService.GetCompanyById(id);
                    if (company?.Krs != null && company.Nip != null)
                    {
                        companyRepository.AddNewCompany(Mapper.Map<CompanyEntity>(company));
                        companyRepository.Save();
                    }
                }
                return company;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}