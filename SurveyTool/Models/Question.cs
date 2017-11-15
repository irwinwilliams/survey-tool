using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class Question
    {
        public Question() {

            QuestionOptions = new List<QuestionOption>();
            Answers = new List<Answer>();

            QuestionId = -1;
            CategoryId = -1;

            IsEnabled = true;
            ModifiedDate = DateTime.Now;
            EntryDate = DateTime.Now;
        }

        [Key]
        [Column("QuestionId")]
        public int QuestionId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string Description { get; set; }

        [DisplayName("Enabled?")]
        public bool IsEnabled { get; set; }

        [DisplayName("Last Modified on")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Created on")]
        public DateTime EntryDate { get; set; }


        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }


    }
}