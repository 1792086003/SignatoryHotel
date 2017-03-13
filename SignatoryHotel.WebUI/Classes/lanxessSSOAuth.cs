using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;



namespace Lanxess.CN.SignatoryHotel.WebUI.Classes
{
    /// <summary>
    /// 访问控制过滤器
    /// </summary>
    public class lanxessSSOAuthFilterAttribute : ActionFilterAttribute
    {
        //定义session key
        public const string SignatoryHotelCWIDSessionKey = "SignatoryHotelCWID";
        public const string SignatoryHotelIsAdminSessionKey = "SignatoryHotelIsAdmin";
        public const string SignatoryHotelSessionTicketSessionKey = "SignatoryHotelSessionTicket";

        //访问前，进行验证过滤
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //初始化session值变量
            var SignatoryHotelCWIDSessionValue = "";
            var SignatoryHotelSessionTicketValue = "";

            if (filterContext.HttpContext.Request.QueryString["cwid"] != null && filterContext.HttpContext.Request.QueryString["ticket"]!=null)
            {
                //从querystring获得cwid 和 sessionticket,用于验证
                SignatoryHotelCWIDSessionValue = filterContext.HttpContext.Request.QueryString["cwid"];
                SignatoryHotelSessionTicketValue = filterContext.HttpContext.Request.QueryString["ticket"];

                if (IsUser(SignatoryHotelCWIDSessionValue.ToUpper(), SignatoryHotelSessionTicketValue))
                {
                    //验证成功，把cwid保存到当前session
                    filterContext.HttpContext.Session.Add(SignatoryHotelCWIDSessionKey, SignatoryHotelCWIDSessionValue);
                    //判断cwid是否为admin,结果保存到session
                    if (IsAdmin(SignatoryHotelCWIDSessionValue))
                    {
                        filterContext.HttpContext.Session.Add(SignatoryHotelIsAdminSessionKey, true);
                    }
                    else
                    {
                        filterContext.HttpContext.Session.Add(SignatoryHotelIsAdminSessionKey, false);
                    }
                    filterContext.Result = new RedirectResult(String.Format("{0}",HttpUtility.UrlDecode(filterContext.HttpContext.Request.QueryString["callbackurl"])));
                }else
                {
                    //验证失败，跳转登陆
                    filterContext.Result = SSOLogOnResult(filterContext.HttpContext.Request.Url.ToString());
                }                
            }
            else
            {
                if(filterContext.HttpContext.Session[SignatoryHotelCWIDSessionKey]!=null)
                {
                    //当前session有CWID信息，直接访问     
                }else
                {
                    //当前session无CWID信息，跳转登录
                    filterContext.Result = SSOLogOnResult(filterContext.HttpContext.Request.Url.ToString());
                }       
            }
            
        }

        /// <summary>
        /// 用户验证
        /// </summary>
        /// <param name="CWID"></param>
        /// <param name="sessionTicket"></param>
        /// <returns></returns>
        private static bool IsUser(string CWID,string sessionTicket)
        {
            xsession.xSession checkUser = new xsession.xSession();
            xsession.validateResult IsUserResult = checkUser.IsAthenticatedEx(sessionTicket.Trim(), CWID);
            if (xsession.validateResult.LOGIN_USER_OK==IsUserResult)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 管理员验证
        /// </summary>
        /// <param name="CWID"></param>
        /// <returns></returns>
        private static bool IsAdmin(string CWID)
        {
            //管理user list，从web.config里获得
            string[] adminArray = ConfigurationManager.AppSettings["LanxessAdmins"].Split(',');
            if(Array.IndexOf(adminArray,CWID)==-1)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 登录站点跳转
        /// </summary>
        /// <param name="callbackPath"></param>
        /// <returns></returns>
        private static ActionResult SSOLogOnResult(string callbackPath)
        {
            return new RedirectResult(string.Format("{0}/login.aspx?AppLink={1}&CallbackURL={2}", ConfigurationManager.AppSettings["LanxessSSO"], HttpUtility.UrlEncode(ConfigurationManager.AppSettings["LanxessSignatoryHotelAppLink"]),HttpUtility.UrlEncode(callbackPath)));
        }
    }
}