using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using NIPv1.DAL_Interfaces;
using NIPv1.Entities;

namespace NIPv1.DAL
{
    public class CompanyRepository : Repository<DataContext>, ICompanyRepository
    {
        public DbSet<CompanyEntity> Company;

        public CompanyRepository(DataContext context) : base(context)
        {
            Company = context.Companies;
        }

        public bool IsCompanyInDatabase(CompanyEntity company)
        {
            if (Company.FirstOrDefault(checkedData => checkedData.Nip.Equals(company.Nip)
                                                      && checkedData.Krs.Equals(company.Krs)
                                                      && checkedData.Regon.Equals(company.Regon)) == null )
                return true;
            return false;
        }

        public CompanyEntity FindCompanyByComparing(CompanyEntity company)
        {
            return Company.FirstOrDefault(checkedData => checkedData.Nip.Equals(company.Nip)
                                                         || checkedData.Krs.Equals(company.Krs)
                                                         || checkedData.Regon.Equals(company.Regon));
        }

        public CompanyEntity GetByNip(string number)
        {
            return Company.FirstOrDefault(checkedData => checkedData.Nip.Equals(number));
        }

        public CompanyEntity GetByKrs(string number)
        {
            return Company.FirstOrDefault(checkedData => checkedData.Krs.Equals(number));
        }

        public CompanyEntity GetByRegon(string number)
        {
            return Company.FirstOrDefault(checkedData => checkedData.Regon.Equals(number));
        }

        public void EditCompany(CompanyEntity givenCompany)
        {
            CompanyEntity company = FindCompanyByComparing(givenCompany);
            if (company == null) throw new InvalidOperationException("Cannot find company in database");
            Company.Remove(company);
            Company.Add(givenCompany);
        }

        public void AddNewCompany(CompanyEntity newCompany)
        {
            Company.Add(newCompany);
        }
    }
}