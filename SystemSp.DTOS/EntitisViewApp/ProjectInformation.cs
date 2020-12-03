using System;
using System.Collections.Generic;
using System.Text;
using SystemSp.DTOS.EntitisIndexApp;

namespace SystemSp.DTOS.EntitisViewApp
{
    public class ProjectInformation
    {
        public ProjectCard ProjectCardInfo { get; set; }
        public virtual List<string> ImagesProject { get; set; }
        public virtual List<string[]> TechnologiesUsed {get;set;}
    }
}
