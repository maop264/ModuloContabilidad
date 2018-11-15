using ModuloContabilidad.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ModuloContabilidad.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index(DateTime? fechaInicio, DateTime? fechaFin, string cliente = "")
        {
            if(fechaInicio != null &&  fechaFin != null || cliente != string.Empty)
            {
                using(ModuloContabilidadModel db = new ModuloContabilidadModel())
                {
                    var datosReporte = db.Database.SqlQuery<Registro>("SP_ObtenerRegistro @FechaInicio, @FechaFin, @Cliente", new SqlParameter("@FechaInicio", fechaInicio), new SqlParameter("@FechaFin", fechaFin), new SqlParameter("@Cliente", cliente)).ToList();
                    ViewBag.FechaInicio = fechaInicio.ToString().Substring(6, 4) + "-" + fechaInicio.ToString().Substring(3, 2) + "-" + fechaInicio.ToString().Substring(0, 2);
                    ViewBag.FechaFin = fechaFin.ToString().Substring(6, 4) + "-" + fechaFin.ToString().Substring(3, 2) + "-" + fechaFin.ToString().Substring(0, 2);
                    ViewBag.Cliente = cliente;
                    return View(datosReporte);
                }
            }

            return View();
        }

        // GET: Reportes/Details/1
        public ActionResult Details (int? idRegistro)
        {
            if (idRegistro == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (ModuloContabilidadModel db = new ModuloContabilidadModel())
            {
                var datosReporte = db.Database.SqlQuery<DatoReporte>("SP_DetalleRegistroXId @IdRegistro", new SqlParameter("@IdRegistro", idRegistro)).ToList();
                return View(datosReporte);
            }
        }
    }
}