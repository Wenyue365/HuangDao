using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HuangDao.Modules
{
    public class UrlRouter
    {


        private static string getEventName(string req)
        {
            Regex reEvent = new Regex(@"/(\w+)\.aspx", RegexOptions.IgnoreCase);
            string str = null;

            Match mch = reEvent.Match(req);
            if (mch != null)
            {
                str = mch.Groups[1].Value;
            }

            return str;
        }

        private static string getDateString(string req)
        {
            Regex reDate = new Regex(@"/(\d{4}\-\d{2}\-\d{2})\.aspx", RegexOptions.IgnoreCase);
            string str = null;

            Match mch = reDate.Match(req);
            if (mch.Length > 0)
            {
                str = mch.Groups[1].Value;
            }

            return str;
        }

        private static string getUrlOfEvent(string strEvent)
        {
            string baseUrl = "\\";
            string resPath = null;

            switch (strEvent)
            {
                case "宜忌":
                    resPath = "divine.aspx";
                    break;
                case "测算":
                    resPath = "divine.aspx";
                    break;
                case "姻缘":
                    resPath = "love.aspx";
                    break;
                default:
                    resPath = null;
                    break;
            }

            return (resPath == null) ? null : (baseUrl + resPath);
        }

        private static string getUrlOfDate(string strDate)
        {
            string baseUrl = "\\huangli.aspx?hld=";

            return (baseUrl + strDate);
        }

        public static string getUrl(string req)
        {
            string trgUrl = null;
            string strDate = getDateString(req);
            if (strDate != null)
            {
                trgUrl = getUrlOfDate(strDate);
            }
            else
            {
                string strEvent = getEventName(req);
                if (strEvent != null)
                {
                    trgUrl = getUrlOfEvent(strEvent);
                }
            }

            return trgUrl;
        }
    }
}