namespace ModuloContabilidad.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Spatial;

    [Table("Registros")]
    public partial class Registro
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registro()
        {
            //RegistroXProductos = new HashSet<RegistroXProducto>();
            RegistroXProductos = new List<RegistroXProducto>();
        }

        [Key]
        public int IdRegistro { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Required]
        //[StringLength(50)]
        public string NumeroFactura { get; set; }

        public int SubTotal { get; set; }

        public int IVA { get; set; }

        public int TotalFactura { get; set; }

        public int IdTipoRegistro { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual TipoRegistro TipoRegistro { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroXProducto> RegistroXProductos { get; set; }
    }

    #region ViewModels
    public class RegistroViewModel
    {
        #region Cabecera
        public int IdCliente { get; set; }
        public int CabeceraProductoId { get; set; }
        public string CabeceraProductoNombre { get; set; }
        public int CabeceraProductoCantidad { get; set; }
        public int CabeceraProductoPrecio { get; set; }
        #endregion

        #region Contenido
        public List<RegistroXProductoViewModel> RegistroXProducto { get; set; }//falta crear viewmodel
        #endregion

        #region Pie
        public int Total()
        {
            return RegistroXProducto.Sum(x => x.Total());
        }
        public DateTime FechaRegistro { get; set; }
        #endregion

        public RegistroViewModel()
        {
            RegistroXProducto = new List<RegistroXProductoViewModel>();//falta crear viewmodel
            Refrescar();
        }

        public void Refrescar()
        {
            CabeceraProductoId = 0;
            CabeceraProductoNombre = null;
            CabeceraProductoCantidad = 1;
            CabeceraProductoPrecio = 0;
        }

        public bool SeAgregoUnProductoValido()
        {
            return !(CabeceraProductoId == 0 || string.IsNullOrEmpty(CabeceraProductoNombre) || CabeceraProductoCantidad == 0 || CabeceraProductoPrecio == 0);
        }

        public bool ExisteEnDetalle(int IdProducto)
        {
            return RegistroXProducto.Any(x => x.IdProducto == IdProducto);
        }

        public void RetirarItemDeDetalle()
        {
            if (RegistroXProducto.Count > 0)
            {
                var detalleARetirar = RegistroXProducto.Where(x => x.Retirar)
                                                        .SingleOrDefault();

                RegistroXProducto.Remove(detalleARetirar);
            }
        }

        public void AgregarItemADetalle()
        {
            RegistroXProducto.Add(new RegistroXProductoViewModel
            {
                IdProducto = CabeceraProductoId,
                ProductoNombre = CabeceraProductoNombre,
                PrecioUnitario = CabeceraProductoPrecio,
                Cantidad = CabeceraProductoCantidad,
            });

            Refrescar();
        }

        public Registro ToModel()
        {
            var registro = new Registro();
            registro.IdCliente = this.IdCliente;
            registro.FechaRegistro = DateTime.Now;
            registro.TotalFactura = this.Total();

            foreach (var d in RegistroXProducto)
            {
                registro.RegistroXProductos.Add(new RegistroXProducto//Definir registroxproducto
                {
                    IdProducto = d.IdProducto,
                    Total = d.Total(),
                    //PrecioUnitario = d.PrecioUnitario,
                    Cantidad = d.Cantidad
                });
            }

            return registro;
        }
    }
    #endregion
}
