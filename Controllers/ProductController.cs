using DotNetExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetExam.Controllers
{
    public class ProductController : Controller
    {
        public object ProductId { get; private set; }
        public object ProductName { get; private set; }
        public object Rate { get; private set; }

        // GET: Product
        public ActionResult Index()
        {
            List<Class1> list = new List<Class1>();
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            scn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = scn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products";

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {


                    list.Add(new Class1 { ProductId = (int)dr["ProductId"], ProductName=(string)dr["ProductName"], Rate=(int)dr["Rate"], Description=(string)dr["Description"], CategoryName=(string)dr["CategoryName"] });
                }

                dr.Close();
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            scn.Close();

            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            scn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = scn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products where ProductId=@id";
            cmd.Parameters.AddWithValue("@id", id);
            Class1 obj = null;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                obj = new Class1
                {
                    ProductId = id,
                    ProductName = dr.GetString(1),
                    Rate = dr.GetInt32(2),
                    Description = dr.GetString(3),
                    CategoryName = dr.GetString(4)


                };
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            scn.Close();
            return View(obj);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection co)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            scn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = scn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products where ProductId= @id";
            cmd.Parameters.AddWithValue("@id", id);
            Class1 obj = null;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                obj = new Class1
                {
                    ProductId = id,
                    ProductName = dr.GetString(1),
                    Rate = dr.GetInt32(2),
                    Description = dr.GetString(3),
                    CategoryName = dr.GetString(4)


                };
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            scn.Close();

            
            
            
            
            
            
            
            
            
            return View(obj);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int ? id, Class1 obj)

        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            scn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = scn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Products set ProductName=@ProductName , Rate=@Rate, Description=@Description, CategoryName=@CategoryName  ";

            cmd.Parameters.AddWithValue("@ProductId", obj.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("@Rate", obj.Rate);
            cmd.Parameters.AddWithValue("@Description", obj.Description);











        
            try
            {
                // TODO: Add update logic here

                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
            finally
            {
                scn.Close();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
