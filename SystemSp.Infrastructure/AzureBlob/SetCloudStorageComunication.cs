using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;
using SystemSp.DTOS.EntitisProjectsApp;

namespace SystemSp.Infrastructure.AzureBlob
{
    public class SetCloudStorageComunication : ISystemSpAzureBlob
    {
        public SetCloudStorageComunication(string azureCS) 
        {
            _key = azureCS;
        }
        private readonly string _key;

        public async Task<List<string>> GetImagesContainer(Dictionary<string, string> imageData, string container)
        {
            try
            {
                var blobClient = new BlobContainerClient(_key, container);
                var imagesItem = new List<string>();
                foreach (KeyValuePair<string, string> img in imageData)
                {
                    BlobClient clientImages = blobClient.GetBlobClient(img.Key);
                    bool exist = await clientImages.ExistsAsync();
                    if (exist)
                    {
                        var response = await clientImages.DownloadAsync();
                        var msAzureFile = new MemoryStream();

                        await response.Value.Content.CopyToAsync(msAzureFile);

                        byte[] byteFile = msAzureFile.ToArray();
                        string imageBase64 = Convert.ToBase64String(byteFile);
                        //Se agregan las imagenes del blob
                        imagesItem.Add($"data:{img.Value};base64,{imageBase64}");
                    }
                    else imagesItem.Add("Nok");
                }
                return imagesItem;
            }
            catch (Exception ex)
            {
                string ms = ex.Message;
                return new List<string> { "Nok", ms};
            }
        }

        public List<InformationDocuments> GetDocumentsContainer(List<InformationDocuments> documentsName, string container)
        {
            try
            {
                var blobClient = new BlobContainerClient(_key, container);
                documentsName.ForEach(bName =>
                { 
                    BlobClient blobResult = blobClient.GetBlobClient(bName.FileName);
                    bName.FileUrl = blobResult.Uri.ToString();
                });
                return documentsName;

            }
            catch (Exception ex)
            {
                return documentsName;
            }
        }

        public async Task SaveBlobImage(Dictionary<string, string> imageData, string container, bool accessLevel)
        {
            try
            {
                PublicAccessType level = (accessLevel) ? PublicAccessType.Blob : PublicAccessType.None;
                var blobService = new BlobServiceClient(_key);
                BlobContainerClient blobContainer = await blobService.CreateBlobContainerAsync(container, level);
                bool containerExist = await blobContainer.ExistsAsync();

                if (containerExist)
                {
                    foreach (KeyValuePair<string, string> img in imageData)
                    {
                        byte[] byteArray = Convert.FromBase64String(img.Value);
                        Stream image = new MemoryStream(byteArray);
                        var blobClient = new BlobClient(_key, container, img.Key);
                        await blobClient.UploadAsync(image);
                    }
                }
            }
            catch (Exception ex)
            {
                string ms = ex.Message;
            }
        }
    }
}
