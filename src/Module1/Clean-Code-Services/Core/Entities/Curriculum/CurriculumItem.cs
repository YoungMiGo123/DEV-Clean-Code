using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Clean_Code_Services.Core.Entities.Curriculum
{
    public class CurriculumItem
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }  
        public string Title { get; set; }
        public string Type { get; set; }    
        public string Material { get; set; } 
        public bool Editing { get; set; }

        bool Active { get; set; }
    }

}