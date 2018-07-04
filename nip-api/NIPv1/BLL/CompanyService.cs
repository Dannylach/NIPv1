using System;
using AutoMapper;
using NIPv1.BLL_Interfaces;
using NIPv1.DAL_Interfaces;
using NIPv1.Entities;
using NIPv1.Models;

namespace NIPv1.BLL
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        
        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public CompanyModel AddNewCompany(CompanyModel newCompany)
        {
            try
            {
                if (companyRepository.IsCompanyInDatabase(Mapper.Map<CompanyEntity>(newCompany)))
                    newCompany.Error = "Couldn't_Add_Company___Error_Occurred: Company_Already_In_Database";
                else
                {

                    companyRepository.AddNewCompany(Mapper.Map<CompanyEntity>(newCompany));
                    companyRepository.Save();
                    newCompany.Error = "Company_Added_Successfully";
                }
            }
            catch (Exception e)
            {
                newCompany.Error = $"Couldn't_Add_Company___Error_Occurred: {e}";
            }
            return newCompany;
        }

        public CompanyModel EditCompany(CompanyModel givenCompany)
        {
            try
            {
                companyRepository.EditCompany(Mapper.Map<CompanyEntity>(givenCompany));
                companyRepository.Save();
                givenCompany.Error = "Company_Edited_Successfully";
            }
            catch (Exception e)
            {
                givenCompany.Error = $"Couldn't_Edit_Company___Error_Occurred: {e}";
            }
            return givenCompany;
        }
    }
}