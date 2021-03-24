using System;
using System.Collections.Generic;

namespace SystemSp.DTOS.EntitisProjectsApp
{
    public class RequestData
    {
        public string RequestName { get; set; }
        public string Departament { get; set; }
        public string City { get; set; }
        public string RequestDescription { get; set; }
        public DateTime? DatePublish { get; set; }
        public string StateRequest { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public List<string> ImagesUrl { get; set; }
    }
}
