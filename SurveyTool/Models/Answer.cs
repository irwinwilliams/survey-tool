using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class Answer
    {
        public Answer() {
            AnswerId = -1;
            QuestionId = -1;
            QuestionOptionId = -1;
            ModifiedDate = DateTime.Now;
            EntryDate = DateTime.Now;
        }

        [Key]
        [Column("AnswerId")]
        public int AnswerId { get; set; }
        public int ResponseId { get; set; }

        [ForeignKey("ResponseId")]
        public virtual Response Response { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public int QuestionOptionId { get; set; }

        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOption QuestionOption { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No Remarks")]
        public string Remarks { get; set; }

        [DisplayName("Last Modified on")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Created on")]
        public DateTime EntryDate { get; set; }

    }
}