using BlazorInputFile;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SystemSP.Intelligence
{
    public class SaveIFiles
    {
        private async Task<string> _getBase64(IFileListEntry file) 
        {
            try
            {
                if (file.Type.Contains("image/") || file.Type.Contains("application/"))
                {

                    var msFile = new MemoryStream();
                    await file.Data.CopyToAsync(msFile);
                    byte[] byteFile = msFile.ToArray();
                    string base64 = Convert.ToBase64String(byteFile);
                    return base64;
                }
                else
                    return "NoK";
            }
            catch (Exception ex)
            {
                string ms = ex.Message;
                return "NoK";
            }

        }
        public async Task<string> GetFileBase64(IFileListEntry file)
            => await _getBase64(file);
    }
}
