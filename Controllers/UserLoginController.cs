using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;
using _100647340PereiraDeSousaA2.Models;
using System.Data;


namespace _100647340PereiraDeSousaA2.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }

        //SQL Connection String
        readonly string connectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True";
        SqlDataReader dr;

        
        //Login Method
        [HttpPost]
        public ActionResult Index(LoginModel acc)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * from Customer WHERE UserName='" + acc.Username + "' and Password='" + acc.Password + "'";
            SqlCommand com = new SqlCommand(query, con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                FormsAuthentication.SetAuthCookie(acc.Username, true);
                Session["username"] = acc.Username.ToString();
                return View("~/Views/Home/Menu.cshtml");
            }
            else
            { 
                ViewData["message"] = "Login Details Failed !";
            }
            con.Close();
            return View();
        }
        public ActionResult CustomerPage()
        {
            return View();
        }


        public ActionResult Logout(LoginModel acc)
        {
            FormsAuthentication.SetAuthCookie(acc.Username, false);
            Session["username"] = null;
            return View("Index");
        }

    }
}