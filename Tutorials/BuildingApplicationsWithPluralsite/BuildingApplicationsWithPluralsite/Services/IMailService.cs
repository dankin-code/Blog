using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingApplicationsWithPluralsite.Services
{
    public interface IMailService
    {
        bool SendMail(string from, string to, string subject, string body)
    }
}