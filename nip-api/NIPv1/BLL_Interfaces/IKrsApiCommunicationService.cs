using System.Threading.Tasks;
using NIPv1.Models;

namespace NIPv1.BLL_Interfaces
{
    public interface IKrsApiCommunicationService
    {
        CompanyModel GetCompanyById(string id);
    }
}
