using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lanxess.CN.SignatoryHotel.BussinessEntity;

namespace Lanxess.CN.SignatoryHotel.WebUI.Controllers
{
    /// <summary>
    /// 用户登录验证控制器
    /// </summary>
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        public ActionResult LogOn()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        //提交用户信息以供验证
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(LoginViewModel model,string returnUrl)
        {
            if(ModelState.IsValid)
            {
                bool result = FormsAuthentication.Authenticate(model.UserName, model.Password);
                if(result)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Hotels");
                    }
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        //注销用户
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Hotels");
        }
    }
}