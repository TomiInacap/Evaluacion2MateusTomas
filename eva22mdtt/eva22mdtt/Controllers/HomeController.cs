using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eva22mdtt.Models;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;



namespace eva22mdtt.Controllers
{
    public class HomeController : Controller
    {

        // public ActionResult Index(SqlConnection bddMDTTEntities2)
        public ActionResult Index()
        {

            return View();
        }


    }
}