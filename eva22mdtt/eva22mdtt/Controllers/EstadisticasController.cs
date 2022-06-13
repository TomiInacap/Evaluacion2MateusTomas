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
    public class EstadisticasController : Controller
    {
        // GET: Estadisticas
        public ActionResult Index()
        {
            bddMDTTEntitiesEva2 db = new bddMDTTEntitiesEva2();

            IEnumerable<Categoria> categoriaQuery = from categoria in db.Categoria select categoria;
            IEnumerable<Producto> productoQuery = from producto in db.Producto select producto;

            List<int> listaIdCategorias = new List<int>();
            foreach (Categoria categoria in categoriaQuery) listaIdCategorias.Add(categoria.idCategoria);

            List<int> listaIdProductos = new List<int>();
            List<int> listaStocks = new List<int>();
            foreach (Producto producto in productoQuery)
            {
                listaIdProductos.Add(producto.idProducto);
                listaStocks.Add(producto.stock);
            }

            float stockTotal = listaStocks.Sum();

            List<float> stockAvgCatIndividual = new List<float>();
            List<int> precioAvgCatIndividual = new List<int>();
            IEnumerable<Producto> productoCatQuery;
            for (int i = 0; i < listaIdCategorias.Count; i++)
            {
                var idCategoria = listaIdCategorias[i];
                productoCatQuery = from producto in db.Producto where producto.IdCategoria == idCategoria select producto;

                List<int> la = new List<int>(); List<int> lb = new List<int>();

                foreach (Producto producto in productoCatQuery)
                {
                    la.Add(producto.stock);
                    lb.Add(producto.precio);
                }

                if (lb.Sum() > 0 || la.Sum() > 0)
                {
                    stockAvgCatIndividual.Add((la.Sum() / stockTotal) * 100);
                    precioAvgCatIndividual.Add(lb.Sum() / lb.Count());
                }
            }

            List<int> listaStockProductos = new List<int>();
            foreach (Producto producto in productoQuery)
            {
                listaStockProductos.Add(producto.stock);
            }

            // Asignar lista a un ViewBag
            ViewBag.NumCategorias = listaIdCategorias.Count();
            ViewBag.IdCategorias = listaIdCategorias;
            ViewBag.ListaPorcentajeCat = stockAvgCatIndividual;
            ViewBag.ListaPrecioPromedioCant = precioAvgCatIndividual.Count();
            ViewBag.ListaPrecioPromedio = precioAvgCatIndividual;


            ViewBag.StockTotal = listaStockProductos.Sum();

            return View();








        }
    }
}