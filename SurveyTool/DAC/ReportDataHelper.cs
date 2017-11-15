using SurveyTool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurveyTool.DAC
{
    public class ReportDataHelper
    {
        private readonly string SELECTALL = "dbo.USP_GetScore";
        public List<ReportViewModel> SelectByID(int SurveyId)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()); //new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTALL;
            cmd.Parameters.AddWithValue("@SurveyId", SurveyId);
            
            return fetchRecords(cmd);
        }

        private List<ReportViewModel> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<ReportViewModel> reports = null;

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    reports = new List<ReportViewModel>();
                    while (dr.Read())
                    {
                        ReportViewModel a = new ReportViewModel();
                        a.SurveyId = Convert.ToInt32(dr["SurveyId"]);
                        a.QuestionOptionId = Convert.ToInt32(dr["QuestionOptionId"]);
                        a.Score = Convert.ToDouble(dr["Score"]);
                        a.Responses = Convert.ToDouble(dr["Responses"]);
                        a.ScorePercentage = Convert.ToDouble(dr["ScorePercentage"]);

                        reports.Add(a);
                    }
                    reports.TrimExcess();
                }
            }
            return reports;
        }

        public List<ReportViewModel> Show(int SurveyId)
        {
            var myListItem = SelectByID(SurveyId);

            return myListItem;
        }

    }
}