using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class Category
    {
        public Category() {

            Questions = new List<Question>();
            CategoryId = -1;
            SurveyId = -1;

            IsEnabled = true;
            ModifiedDate = DateTime.Now;
            EntryDate = DateTime.Now;
        }

        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        public int SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }

        [DisplayName("Category Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Enabled?")]
        public bool IsEnabled { get; set; }

        [DisplayName("Last Modified on")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Created on")]
        public DateTime EntryDate { get; set; }

        public virtual ICollection<Question> Questions { get; set; }


    }
}