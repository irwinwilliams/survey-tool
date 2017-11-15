using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyTool.Models
{
    public class Client
    {
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}