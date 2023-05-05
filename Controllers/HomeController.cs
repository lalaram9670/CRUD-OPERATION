using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_OPERATION.Models;
using System.Data;
using System.Data.SqlClient;
namespace CRUD_OPERATION.Controllers
{
    public class HomeController : Controller
    {
        DBManager dm = new DBManager();
        public ActionResult ShowAll()
        {
            string cmd = "Select *from Tbl_Product";
            DataTable dt = dm.ExecuteMyQuery(cmd);
            List<Product> LstPro = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                Product p = new Product();
                p.ProductId = int.Parse(dr["ProductId"].ToString());
                p.ProductName = dr["ProductName"].ToString();
                p.CategoryId = dr["CategoryId"].ToString();
                p.CotegoryName = dr["CotegoryName"].ToString();
                p.Date_of_Reg = dr["Date_of_Reg"].ToString();
                LstPro.Add(p);
            }
            return View(LstPro);
        }
        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(Product p)
        {
            p.Date_of_Reg = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            string cmd = "Insert into Tbl_Product values('" + p.ProductName + "','" + p.CategoryId + "','" + p.CotegoryName + "','" + p.Date_of_Reg + "')";
            bool b = dm.ExecuteMyNonQuery(cmd);
            ViewBag.Message = b == true ? "ProductId record saved successfully." : "Sorry! unable to save Product record.";
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            string cmd = "Select * from ProductId where ProductId='" + id + "'";
            DataTable dt = dm.ExecuteMyQuery(cmd);
            Product p = new Product();
            if (dt.Rows.Count > 0)
            {
                p.ProductId = int.Parse(dt.Rows[0]["ProductId"].ToString());
                p.ProductName = dt.Rows[0]["ProductName"].ToString();
                p.CategoryId = dt.Rows[0]["CategoryId"].ToString() ;
                p.CotegoryName = dt.Rows[0]["CotegoryName"].ToString();
                p.Date_of_Reg =dt.Rows[0]["Date_of_Reg"].ToString();
            }
            return View(p);
        }
        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            string cmd = "update ProductId set Name='" + p.ProductName + "',CategoryId='" + p.CategoryId + "',CotegoryName='" + p.CotegoryName + "' where ProductId=''" + p.ProductId +"'";
            bool b =dm.ExecuteMyNonQuery(cmd);
           TempData["Message"] = b == true ? "Record updated successfully." : "Sorry! unable to update record.";
            return RedirectToAction("ShowAll");
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            string cmd = "Delete from Tbl_Product where ProductId='" + id + "'";
            bool b = dm.ExecuteMyNonQuery(cmd);
            TempData["Message"] = b == true ? "Record deleted successfully." : "Sorry! unable to delete record.";
            return RedirectToAction("ShowAll");
        }
    }
}