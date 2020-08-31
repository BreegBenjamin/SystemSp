using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;

namespace SystemSP.Intelligence
{
    public class SaveIFiles
    {
        private async Task<string> _getImage(IFileListEntry file) 
        {
            string src = string.Empty;
            if (file.Type.Contains("image/"))
            {
                var msFile = new MemoryStream();
                await file.Data.CopyToAsync(msFile);
                byte[] byteFile = msFile.ToArray();
                string base64 = Convert.ToBase64String(byteFile);
                src = $"data:{file.Type};base64,{base64}";
            }
            else
                src = "NoK";
            return src;
        }
        private async Task<string> _getFiles(IFileListEntry file) 
        {
            string archivo = string.Empty;
            if (file.Type.Contains("application/"))
            {
                var msFile = new MemoryStream();
                await file.Data.CopyToAsync(msFile);
                StreamReader reader = new StreamReader(msFile);
                try
                {
                    archivo = reader.ReadToEnd();
                }
                catch(Exception ex)
                {
                    archivo = "NoK";
                }
                finally 
                {
                    reader.Close();
                }
            }
            else
                archivo = "NoK";
            return archivo;
        }
        public async Task<string> GetImages(IFileListEntry file)
            => await _getImage(file);
        public async Task<string> SaveFiles(IFileListEntry file)
            => await _getFiles(file);
    }
}
