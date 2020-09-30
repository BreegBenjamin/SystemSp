using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class FormProjectApp
    {
        public int UserId { get; set; }
        public string NameProject { get; set; }
        public string Category { get; set; }
        public string Departament { get; set; }
        public string TrainingCity { get; set; }
        public string TrainingType { get; set; }
        public string ProjectDate { get; set; }
        public string ProjectDescription { get; set; }
        public string SenaName { get; set; }
        public List<ApprenticeData> ApprenticesData { get; set; }
        public List<string> ImagesProject { get; set; }
        public string TechFrontEnd { get; set; }
        public string TechBackEnd { get; set; }
        public string TechDataBase { get; set; }
    }
}
