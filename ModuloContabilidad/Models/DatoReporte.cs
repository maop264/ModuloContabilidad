using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloContabilidad.Models
{
    public class DatoReporte
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NumeroFactura { get; set; }
        public double SubTotal { get; set; }
        public double IVAFactura { get; set; }
        public int TotalFactura { get; set; }
        public string TipoRegistro { get; set; }
        public string Concepto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public string NombreProducto { get; set; }
        public string CodReferencia { get; set; }
        public string Descripcion { get; set; }
        public int ValorUnitario { get; set; }
        public int IVAProducto { get; set; }
    }
}