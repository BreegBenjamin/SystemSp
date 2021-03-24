using System.Collections.Generic;
using System.Threading.Tasks;
using SystemSp.DTOS.EntitisProjectsApp;

namespace SystemSp.Core.Interfaces
{
    public interface ISystemSpAzureBlob
    {
        Task SaveBlobImage(Dictionary<string, string> imageData, string container, bool accessLevel);
        Task<List<string>> GetImagesContainer(Dictionary<string, string> imageData, string container);
        List<InformationDocuments> GetDocumentsContainer(List<InformationDocuments> documentsName,string container);
    }
}
