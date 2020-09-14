using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class FormativeProject
    {
        public FormativeProject()
        {
            DocumentProject = new HashSet<DocumentProject>();
            ImagesProject = new HashSet<ImagesProject>();
            TeamProject = new HashSet<TeamProject>();
        }

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

        public virtual UserApp IdUserNavigation { get; set; }
        public virtual ICollection<DocumentProject> DocumentProject { get; set; }
        public virtual ICollection<ImagesProject> ImagesProject { get; set; }
        public virtual ICollection<TeamProject> TeamProject { get; set; }
    }
}
