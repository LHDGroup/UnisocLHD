namespace Spreadtrum.LHD.Mvc.Controllers
{
    using KaYi.Utilities;
    using Spreadtrum.LHD.Mvc;
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string name = base.User.Identity.Name;
            if (ConfigurationManager.AppSettings["ADLogin"] == "1")
            {
                string nextUrl = string.Empty;
                //base.Session.Contents["User"] = AdLoginHelper.TryAdLogin(name, out nextUrl, "Session Start");
                System.Web.HttpContext.Current.Session["User"] = AdLoginHelper.TryAdLogin(name, out nextUrl, "Session Start");
                if (!StringHelper.isNullOrEmpty(nextUrl))
                {
                    base.Response.Redirect(nextUrl);
                }
            }
            else
            {
                //base.Response.Redirect("/Accounts/Login");
                base.Response.Redirect("https://sdx.unisoc.com/_forms/default.aspx?ReturnUrl=%2f_layouts%2f15%2fAuthenticate.aspx%3fSource%3d%252F&Source=" + HttpUtility.UrlEncode(base.Request.Url.ToString(), System.Text.Encoding.UTF8), true);
            }
            return null;
        }
    }
}

