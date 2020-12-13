using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class FormRequest
    {
        public int IdUser { get; set; }
        public string RequestName { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string RequestDescription { get; set; }
        public string Category { get; set; }
        public string UserName { get; set; }
        public List<FileStreamData> FilesData { get; set; }
    }
}
