using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eva22mdtt.Models;
using eva22mdtt.Controllers;
using EntityState = System.Data.Entity.EntityState;
using System.Data.SqlClient;

namespace eva22mdtt.Controllers
{
    public class BusquedasController : Controller
    {
        //private bddMDTTEntitiesEva2 db = new bddMDTTEntitiesEva2();
        bddMDTTEntities2 db = new bddMDTTEntities2();
        // GET: Busquedas
        public async Task<ActionResult> Index()
        {
            List<Producto> prods = db.Producto.ToList();
            List<Categoria> cates = db.Categoria.ToList();
            var averem = from c in cates
                         join p in prods on c.idCategoria equals p.IdCategoria into table1
                         from p in table1.DefaultIfEmpty()
                         select new multiple { cates = c, prods = p };
            return View(averem);



            //var producto = db.Producto.Include(p => p.Categoria);
            //return View(await producto.ToListAsync());
        }

    }
}
