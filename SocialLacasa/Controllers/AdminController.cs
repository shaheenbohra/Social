using Newtonsoft.Json.Linq;
using SocialLacasa.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SocialLacasa.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PlaceOrder()
        {

            var request = (HttpWebRequest)WebRequest.Create("https://socialwizards.com/api/v2?key=4319270ac33c7579f1d4f8d4c60357a5&action=services");
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            var response = (HttpWebResponse)request.GetResponse();
            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            var releases = JArray.Parse(content);
            DataTable dtorders = new DataTable();

            var objUser = new User();
            dtorders = objUser.Getorders("0", "0");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtorders);
            return View(ds);
        }
    }
}