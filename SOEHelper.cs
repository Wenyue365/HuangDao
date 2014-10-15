﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;

namespace HuangDao
{
    public class SEOHelper
    {
        public static string getPageTile(string pageName)
        {
            string strDate = DateTime.Now.ToLongDateString();

            string strTitleTmpl = "问曰 {1} {0}老黄历查询 {0}择吉老黄历 {0}黄历 {0}农历";

            return string.Format(strTitleTmpl, strDate, pageName);
        }

        public static string getWebsiteKeywords()
        {
            string strDate = DateTime.Now.ToLongDateString();

            string strKeywordsTmpl = 
            "{0}日黄历,老黄历,老皇历,黄历,皇历,农历,吉日,老皇历," +
            "问曰老黄历,黄道吉日,{0}黄历查询," +
            "{0}老黄历查询,老黄历{0}," + 
            "{0},{0}农历,{0}农历查询,{0}日历";

            return string.Format(strKeywordsTmpl, strDate);
        }

        public static string getWebsiteDesciptions()
        {
            string strDate = DateTime.Now.ToLongDateString();
            string strYear = DateTime.Now.Year.ToString();
            string strDescriptionTmpl = 
                "问曰黄历提供老黄历查询，黄历每日吉凶宜忌查询、农历查询、黄道吉日查询、"+
                "时辰凶吉查询，提供免费搬家吉日查询、入宅吉日查询、结婚吉日查询、开业吉日查询等，"+
                "以及生肖属相运程分析，免费占卜算命，算卦占卜等。{0}黄历,"+
                "{0}黄历查询{1},{0}老黄历,老黄历{0},"+
                "{0}老黄历查询,{0}时辰吉凶宜忌";

            return string.Format(strDescriptionTmpl, strDate, strYear);
        }

        public static void initMeta(HtmlMeta htmlKeyword, HtmlMeta htmlDescription)
        {
            HtmlMeta[] metas = { htmlKeyword, htmlDescription };

            metas[0].Name = "keywords";
            metas[0].Content = SEOHelper.getWebsiteKeywords();

            metas[1].Name = "description";
            metas[1].Content = SEOHelper.getWebsiteDesciptions();
        }
    }

    class CNZZ
    {
        private int SiteId = 1253138335; /* 网站 ID */
        private const string ImageDomain = "c.cnzz.com";
        public CNZZ(int SiteId = 0)
        {
            if (SiteId != 0)
            {
                this.SiteId = SiteId;
            }
        }

        public void setup(Page thisPage)
        {
            Image cnzzImg = new Image();
            cnzzImg.ImageUrl = TrackPageView();
            cnzzImg.Width = 0;
            cnzzImg.Height = 0;
            cnzzImg.Style.Add("display", "none");
            thisPage.Controls.Add(cnzzImg);
        }
        private string TrackPageView()
        {
            HttpRequest request = HttpContext.Current.Request;
            string scheme = request != null ? request.IsSecureConnection ? "https" : "http" : "http";
            string referer = request != null && request.UrlReferrer != null && "" != request.UrlReferrer.ToString() ? request.UrlReferrer.ToString() : "";
            String rnd = new Random().Next(0x7fffffff).ToString();
            return scheme + "://" + CNZZ.ImageDomain + "/wapstat.php" + "?siteid=" + this.SiteId + "&r=" + HttpUtility.UrlEncode(referer) + "&rnd=" + rnd;
        }
    }

    class SiteMap
    {
         /// <summary>
        /// 生成网站地图
        /// </summary>
        /// <returns></returns>
        public static bool BuildSitemap()
        {
            try
            {
                string RootDirectory = AppDomain.CurrentDomain.BaseDirectory;
                XmlTextWriter Writer = new XmlTextWriter(HttpContext.Current.Server.MapPath("~/GoogleSitemaps.xml"), Encoding.GetEncoding("utf-8"));
                Writer.Formatting = Formatting.Indented;
                Writer.WriteStartDocument();
                Writer.WriteStartElement("urlset", "http://www.google.com/schemas/sitemap/0.84");
                //遍历扫描网站所有文件
                showfiles(RootDirectory, Writer);

                Writer.WriteEndElement();
                Writer.WriteEndDocument();
                Writer.Close();
                return true;

            }
            catch (Exception err)
            {
                return false;
            }
        }
        
        //遍历扫描网站所有文件
        static void showfiles(string dirpath, XmlTextWriter Writer)
        {
            bool IsRead = true;
            string[] NotRead ={ "App_Data", "Bin", "fckeditor", "js", "MyAdmin", "PowerChatRoom" };//排除这些文件夹
            foreach (string s in NotRead)
            {
                string dirname = dirpath.Substring(dirpath.LastIndexOf(@"\") + 1);
                if (dirname == s)
                {
                    IsRead = false;
                    break;
                }
            }
            if (!IsRead)
                return;

            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirpath);
                foreach (FileInfo f in dir.GetFiles())
                {
                    string path = dir.FullName.Replace(AppDomain.CurrentDomain.BaseDirectory, "");//文件相对目录
                    //HttpContext.Current.Response.Write(AppDomain.CurrentDomain.BaseDirectory + "**********" + dir.FullName + "<br>");
                    Writer.WriteStartElement("url");

                    Writer.WriteStartElement("loc");
                    StringBuilder sb = new StringBuilder("/" + path + "/" + f.Name);
                    sb.Replace("//", "/").Replace(@"\", "/");
                    Writer.WriteString(ConfigurationManager.AppSettings["WebSiteUrl"].ToString() + sb.ToString());
                    Writer.WriteEndElement();

                    Writer.WriteStartElement("lastmod");
                    Writer.WriteString(string.Format("{0:yyyy-MM-dd}", f.LastWriteTime));
                    Writer.WriteEndElement();

                    Writer.WriteStartElement("changefreq");
                    Writer.WriteString("always");//更新频率：always：经常，hourly：小时，daily：天，weekly：周，monthly：月，yearly：年 
                    Writer.WriteEndElement();

                    Writer.WriteStartElement("priority");
                    Writer.WriteString("0.8");//相对于其他页面的优先权，此值定于0.0 - 1.0之间 
                    Writer.WriteEndElement();

                    Writer.WriteEndElement();
                }

                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    showfiles(d.FullName, Writer);
                }
            }
            catch (Exception) { }
        }
    }
}