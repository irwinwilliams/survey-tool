using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class Response
    {
        public Response() {

            Answers = new List<Answer>();
            ResponseId = -1;
            SurveyId = -1;
            CreatedBy = "Unknown";
            EntryDate = DateTime.Now;
        }

        [Key]
        [Column("ResponseId")]
        public int ResponseId { get; set; }

        public int SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }

        public string CreatedBy { get; set; }

        public DateTime EntryDate { get; set; }

        public ICollection<Answer> Answers { get; set; }


    }
}