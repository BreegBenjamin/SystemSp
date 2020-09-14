using System.Threading.Tasks;
using SystemSp.Intellengece.WebServiceBusiness;

namespace SystemSp.Intellengece.Interfaces
{
    public interface IControllerService
    {
        Task<T> GetDataFromService<T>(Controllers baseUri);
    }
}
