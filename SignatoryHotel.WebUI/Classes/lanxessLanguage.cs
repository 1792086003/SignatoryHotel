using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace Lanxess.CN.SignatoryHotel.WebUI.Classes
{
    /// <summary>
    /// 区域语言过滤器
    /// </summary>
    public class lanxessLanguageFilterAttribute:ActionFilterAttribute
    {
        //定义session key
        public const string SignatoryHotelLanguageSessionKey = "SignatoryHotelLanguage";
        //访问前，进行语言过滤
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if (filterContext.RouteData.Values["language"] != null && 
                !string.IsNullOrWhiteSpace(filterContext.RouteData.Values["language"].ToString()))
            {
                var language = filterContext.RouteData.Values["language"].ToString();

                if (isAvailableLanguage(language))
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(language);
                    filterContext.HttpContext.Session.Add(SignatoryHotelLanguageSessionKey, language);
                    filterContext.RouteData.Values["language"] = language;
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture =
                    CultureInfo.CreateSpecificCulture(filterContext.HttpContext.Request.UserLanguages[0]);
                    filterContext.HttpContext.Session.Add(SignatoryHotelLanguageSessionKey, filterContext.HttpContext.Request.UserLanguages[0]);
                    filterContext.RouteData.Values["language"] = filterContext.HttpContext.Request.UserLanguages[0];
                }         
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = 
                    CultureInfo.CreateSpecificCulture(filterContext.HttpContext.Request.UserLanguages[0]);
                filterContext.HttpContext.Session.Add(SignatoryHotelLanguageSessionKey, filterContext.HttpContext.Request.UserLanguages[0]);
                filterContext.RouteData.Values["language"] = filterContext.HttpContext.Request.UserLanguages[0];
            }

            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 判断是否为可用语言
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        private static bool isAvailableLanguage(string language)
        {
            string[] languageArray = ConfigurationManager.AppSettings["LanxessLanguages"].Split(',');
            if (Array.IndexOf(languageArray, language) == -1)
            {
                return false;
            }
            return true;
        }
    }
}