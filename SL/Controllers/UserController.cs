using SocialLacasa.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialLacasa.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Orders(string status="")
        {
            DataTable dtorders = new DataTable();

            var objUser = new User();
            dtorders = objUser.Getorders(Session["UserId"].ToString(), status);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtorders);
            return View(ds);
        }
        public ActionResult MassOrders()
        {
            return View();
        }
        public ActionResult AddFunds()
        {
            return View();
        }
        public ActionResult Subscriptions()
        {
            return View();
        }
        public ActionResult NewOrder()
        {
            var objUser = new User();
            DataTable dtCategory = objUser.GetAllCategory();
            DataRow newRow = dtCategory.NewRow();
            newRow[0] = "0";
            newRow[1] = "Select";
            dtCategory.Rows.InsertAt(newRow, 0);
            ViewBag.CatagoryName = new SelectList(dtCategory.AsDataView(), "CatagoryId", "CatagoryName");//dtMessages.AsEnumerable().ToList();

            //ViewBag.UserId = Session["UserId"];
            return View();
        }
        public ActionResult Terms()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
    }
}