using System;

namespace SystemSp.Intellengece.Entities
{
    public partial class FormativeProject
    {
        public int IdProject { get; set; }
        public int? IdLinked { get; set; }
        public int? IdUser { get; set; }
        public DateTime? PostData { get; set; }
        public string Departament { get; set; }
        public string City { get; set; }
        public bool? StateProject { get; set; }
        public string DescriptionProject { get; set; }
        public string NameSena { get; set; }
        public string ProjectName { get; set; }
        public string Category { get; set; }
        public string TechnologiesBackend { get; set; }
        public string TechnologiesFrontend { get; set; }
        public string TechnologiesDataBase { get; set; }
    }
}
