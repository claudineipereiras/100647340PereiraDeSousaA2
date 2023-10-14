/* DESIGNER: Claudinei Pereira de Sousa (100647340)
   EXERCISE: Assignment 02
   TASK: Doonut Website - ASP.NET MVC Project */


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _100647340PereiraDeSousaA2.Models;
using _100647340PereiraDeSousaA2.Controllers;

namespace _100647340PereiraDeSousaA2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        //SQL connection String
        readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True";
       

        public ActionResult Index()
        {
            DataTable Customer = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * From Customer", sqlCon);
                sqlData.Fill(Customer);
            }
            return View(Customer);
        }


        // GET: Customer/Create
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customerModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Customer VALUES(@FirstName,@LastName,@Phone, @Email, @UserName, @Password)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@FirstName", customerModel.FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", customerModel.LastName);
                sqlCmd.Parameters.AddWithValue("@Phone", customerModel.Phone);
                sqlCmd.Parameters.AddWithValue("@Email", customerModel.Email);
                sqlCmd.Parameters.AddWithValue("@UserName", customerModel.UserName);
                sqlCmd.Parameters.AddWithValue("@Password", customerModel.Password);

                sqlCmd.ExecuteNonQuery();
            }
            return View("ThankYou");
        }


        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerModel customerModel = new CustomerModel();
            DataTable customerData = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Customer Where CustomerID = @CustomerID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@CustomerID", id);
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


        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerModel customerModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Customer SET FirstName = @FirstName , LastName= @LastName , Phone = @Phone, Email = @Email, UserName = @UserName, Password = @Password WHERE CustomerID = @CustomerID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomerID", customerModel.CustomerID);
                sqlCmd.Parameters.AddWithValue("@FirstName", customerModel.FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", customerModel.LastName);
                sqlCmd.Parameters.AddWithValue("@Phone", customerModel.Phone);
                sqlCmd.Parameters.AddWithValue("@Email", customerModel.Email);
                sqlCmd.Parameters.AddWithValue("@UserName", customerModel.UserName);
                sqlCmd.Parameters.AddWithValue("@Password", customerModel.Password);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomerID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


       
    }
}
