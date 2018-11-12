using ModuloContabilidad.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
                    var datosReporte = db.Database.SqlQuery<DatoReporte>("SP_Reportes @FechaInicio, @FechaFin, @Cliente", new SqlParameter("@FechaInicio", fechaInicio), new SqlParameter("@FechaFin", fechaFin), new SqlParameter("@Cliente", cliente)).ToList();
                    return View(datosReporte);
                }
            }

            return View();
        }
    }
}