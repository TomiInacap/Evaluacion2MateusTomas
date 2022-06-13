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
using EntityState = System.Data.Entity.EntityState;

namespace eva22mdtt.Controllers
{
    public class BusquedasController : Controller
    {
        private bddMDTTEntitiesEva2 db = new bddMDTTEntitiesEva2();

        // GET: Busquedas
        public async Task<ActionResult> Index()
        {
            var producto = db.Producto.Include(p => p.Categoria);
            return View(await producto.ToListAsync());
        }

        // GET: Busquedas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Producto.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
