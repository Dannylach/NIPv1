using NIPv1.DAL;
using NIPv1.Entities;

namespace NIPv1.DAL_Interfaces
{
    public interface ICompanyRepository : IRepository<DataContext>
    {
        CompanyEntity GetByNip(string number);

        CompanyEntity GetByKrs(string number);

        CompanyEntity GetByRegon(string number);

        bool IsCompanyInDatabase(CompanyEntity company);

        CompanyEntity FindCompanyByComparing(CompanyEntity company);

        void EditCompany(CompanyEntity givenCompany);

        void AddNewCompany(CompanyEntity NewCompany);
    }
}
