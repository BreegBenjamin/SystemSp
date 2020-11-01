using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SystemSp.Core.Interfaces
{
    public interface ISystemSpAzureBlob
    {
        Task SaveBlobImage(Dictionary<string, string> imageData, string container);
        Task<List<string>> GetImagesContainer(Dictionary<string, string> imageData, string container);
    }
}
