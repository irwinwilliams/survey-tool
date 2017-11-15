using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class ReportViewModel
    {
        public int SurveyId { get; set; }
        public int QuestionOptionId { get; set; }
        public double Score { get; set; }
        public double Responses { get; set; }
        public double ScorePercentage { get; set; }
    }
}