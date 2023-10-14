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
            string query = "SELECT * from Customer WHERE Email='" + acc.Email + "' and Password='" + acc.Password + "'";
            SqlCommand com = new SqlCommand(query, con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                FormsAuthentication.SetAuthCookie(acc.userName, true);
                Session["username"] = acc.userName.ToString();
                return View("CustomerPage");
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

        public ActionResult Edit(LoginModel acc)
        {
            CustomerModel customerModel = new CustomerModel();
            DataTable customerData = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Customer Where CustomerID = @CustomerID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@CustomerID", acc);
                sqlDa.Fill(customerData);
            }
            if (customerData.Rows.Count == 1)
            {
                customerModel.CustomerID = Convert.ToInt32(customerData.Rows[0][0].ToString());
                customerModel.FirstName = customerData.Rows[0][1].ToString();
                customerModel.LastName = customerData.Rows[0][2].ToString();
                customerModel.Phone = Convert.ToInt32(customerData.Rows[0][3].ToString());
                customerModel.Email = customerData.Rows[0][4].ToString();
                customerModel.UserName = customerData.Rows[0][5].ToString();
                customerModel.Password = customerData.Rows[0][6].ToString();
                return View(customerModel);
            }
            else
                return RedirectToAction("Index");
        }

    }
}