using EMaS_MVC.HelperClass;
using EMaS_MVC.Models;
using EMaS_MVC.Models.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EMaS_MVC.Controllers
{

    public class HomeController : Controller
    {
        private bool userAuthentication = false;
        private GlobalConnectionHelper db = GlobalConnectionHelper.getInstance();

        private appContext _appDb = new appContext();
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {


            string strQry = string.Format("SELECT SU.* FROM CM_SYSTEM_USERS_ex SU, CM_CMP_BRANCH CB, CM_COMPANY CO " +
                   "WHERE SU.SYS_USR_LOGIN_NAME = '{0}' AND SU.SYS_USR_PASS = '{1}'", user.SYS_USR_LOGIN_NAME, user.SYS_USR_PASS);
            var User = db.getData<UserViewModel>(strQry, null);



            if (User.Count > 0)
            {
                userAuthentication = true;
                FormsAuthentication.SetAuthCookie(User[0].SYS_USR_ID, true);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult Index()
        {
            if (GetLoginUserData() == null)
                return Redirect("~/Home/Login");
            ViewBag.chkAuth = userAuthentication;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string button3)
        {
            if (GetLoginUserData() == null)
                return Redirect("~/Home/Login");
            else
            {
                return View();
            }

        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect("~/Home/Login");

        }
        public ActionResult About()
        {
            if (GetLoginUserData() == null)
                return Redirect("~/Home/Login");
            else
            {

                var data = _appDb.Users.Take(20).ToList();
                ViewBag.users = data;
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public static string GetLoginUserData()
        {
            HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                return null;
            }
            else
            {
                FormsAuthenticationTicket encTicket = FormsAuthentication.Decrypt(authCookie.Value);
                return encTicket.Name;
            }
        }
    }
}