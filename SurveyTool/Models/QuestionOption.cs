using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class QuestionOption
    {
        public QuestionOption() {
            Answers = new List<Answer>();

            QuestionOptionId = -1;

            IsEnabled = true;
            ModifiedDate = DateTime.Now;
            EntryDate = DateTime.Now;
        }

        [Key]
        [Column("QuestionOptionId")]
        public int QuestionOptionId { get; set; }

        [DisplayName("Question")]
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        [DisplayName("Option Name")]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayName("Enabled?")]
        public bool IsEnabled { get; set; }

        [DisplayName("Last Modified on")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Created on")]
        public DateTime EntryDate { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

    }
}