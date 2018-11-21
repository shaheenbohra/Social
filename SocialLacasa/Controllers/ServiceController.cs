using SocialLacasa.DataLayer;
using SocialLacasa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialLacasa.Controllers
{
    public class ServiceController : Controller
    {
        
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult BindServices(string category)
        {
            var objUser = new User();
            DataTable dtServices = objUser.BindServices(category);
           
            var myEnumerable = dtServices.AsEnumerable();

            List<Services> lstServices =
                (from item in myEnumerable
                 select new Services
                 {
                     SWserviceId = item.Field<Int32>("SWserviceId"),
                     ServiceType = item.Field<string>("ServiceType"),
                     Description = item.Field<string>("Description"),
                     Rate = item.Field<decimal>("Rate")

                 }).ToList();
            return Json(lstServices, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveNewOrder(string category, string service, string link, string quantity, decimal charge)
        {
            var objUser = new User();
            string issucess = "0";
            List<string> Result = new List<string>();
            try
            {
                objUser.SaveNewOrder(category, service, link, quantity, charge, Session["UserId"].ToString());
                issucess = "1";
            }
            catch (Exception ex)
            {
                issucess = ex.Message.ToString();
            }

            Result.Add(issucess);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        //Action called when user is registered
        public JsonResult SaveUser(string userName, string password, string email)
        {
            var objUser = new User();
            string issucess = "0";
            List<string> Result = new List<string>();
            try
            {
                objUser.SaveUser(userName, password, email);
                issucess = "1";
            }
            catch (Exception ex)
            {
                issucess = ex.Message.ToString();
            }

            Result.Add(issucess);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckUser(string userName, string password)
        {
            var objUser = new User();
            string isExist = "0";
            List<string> Result = new List<string>();
            try
            {
                isExist = objUser.CheckUser(userName, password);
                Session["UserId"] = isExist;
            }
            catch (Exception ex)
            {
                isExist = ex.Message.ToString();
            }

            Result.Add(isExist);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult changePassword(string username,string oldpassword,string newpassword) {
            string res="0";
            var objUser = new User();
            List<string> Result = new List<string>();
            try
            {
                res = objUser.changePassword(username, oldpassword,newpassword);
            }
            catch (Exception ex)
            {
            }

            Result.Add(res);
            return Json(Result, JsonRequestBehavior.AllowGet);

        }

    }

}