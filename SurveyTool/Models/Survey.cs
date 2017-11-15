using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class Survey
    {
        public Survey() {
            Categories = new List<Category>();
            Responses = new List<Response>();

            SurveyId = -1;
            
            IsEnabled = true;
            ModifiedDate = DateTime.Now;
            EntryDate = DateTime.Now;
        }

        [Key]
        [Column("SurveyId")]
        public int SurveyId { get; set; }


        [DisplayName("Survey Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Enabled?")]
        public bool IsEnabled { get; set; }

        [DisplayName("Last Modified on")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Created on")]
        public DateTime EntryDate { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}